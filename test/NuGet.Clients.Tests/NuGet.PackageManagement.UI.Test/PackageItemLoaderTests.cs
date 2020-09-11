// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;
using Moq;
using NuGet.Configuration;
using NuGet.PackageManagement.VisualStudio;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Test.Utility;
using NuGet.Versioning;
using NuGet.VisualStudio;
using NuGet.VisualStudio.Internal.Contracts;
using Test.Utility;
using Xunit;

namespace NuGet.PackageManagement.UI.Test
{
    [Collection(MockedVS.Collection)]
    public class PackageItemLoaderTests : IDisposable
    {
        private const string TestSearchTerm = "nuget";
        private JoinableTaskContext _joinableTaskContext;

        public PackageItemLoaderTests()
        {
#pragma warning disable VSSDK005 // Avoid instantiating JoinableTaskContext
            _joinableTaskContext = new JoinableTaskContext(Thread.CurrentThread, SynchronizationContext.Current);
#pragma warning restore VSSDK005 // Avoid instantiating JoinableTaskContext

            NuGetUIThreadHelper.SetCustomJoinableTaskFactory(_joinableTaskContext.Factory);
        }

        public void Dispose()
        {
            _joinableTaskContext?.Dispose();
        }

        [Fact]
        public async Task MultipleSourcesPrefixReserved_Works()
        {
            var solutionManager = Mock.Of<INuGetSolutionManagerService>();
            var uiContext = Mock.Of<INuGetUIContext>();
            var searchService = new Mock<INuGetSearchService>(MockBehavior.Strict);

            var packageSearchMetadata = new List<PackageSearchMetadataContextInfo>()
            {
                new PackageSearchMetadataContextInfo()
                {
                    Identity = new PackageIdentity("NuGet.org", new NuGetVersion("1.0")),
                    PrefixReserved = true
                }
            };

            var searchResult = new SearchResultContextInfo(packageSearchMetadata, new Dictionary<string, LoadingStatus> { { "Completed", LoadingStatus.Ready } }, false);

            searchService.Setup(x =>
                x.SearchAsync(
                    It.IsAny<IReadOnlyCollection<IProjectContextInfo>>(),
                    It.IsAny<IReadOnlyCollection<PackageSource>>(),
                    It.IsAny<string>(),
                    It.IsAny<SearchFilter>(),
                    It.IsAny<NuGet.VisualStudio.Internal.Contracts.ItemFilter>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<SearchResultContextInfo>(searchResult));

            searchService.Setup(x =>
                x.RefreshSearchAsync(It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<SearchResultContextInfo>(searchResult));

            Mock.Get(uiContext)
                .Setup(x => x.SolutionManagerService)
                .Returns(solutionManager);

            var source1 = new PackageSource("https://dotnet.myget.org/F/nuget-volatile/api/v3/index.json", "NuGetVolatile");
            var source2 = new PackageSource("https://api.nuget.org/v3/index.json", "NuGet.org");

            var context = new PackageLoadContext(false, uiContext);
            var loader = await PackageItemLoader.CreateAsync(context, new List<PackageSource> { source1, source2 }, NuGet.VisualStudio.Internal.Contracts.ItemFilter.All, searchService.Object, "nuget");

            await loader.LoadNextAsync(null, CancellationToken.None);
            var items = loader.GetCurrent();

            Assert.NotEmpty(items);

            // All items should not have a prefix reserved because the feed is multisource
            foreach (var item in items)
            {
                Assert.False(item.PrefixReserved);
            }
        }

        [Fact]
        public async Task PackageReader_NotNull()
        {
            // Prepare
            var solutionManager = Mock.Of<INuGetSolutionManagerService>();
            var uiContext = Mock.Of<INuGetUIContext>();
            Mock.Get(uiContext)
                .Setup(x => x.SolutionManagerService)
                .Returns(solutionManager);
            var searchService = new Mock<INuGetSearchService>(MockBehavior.Strict);

            var packageSearchMetadata = new List<PackageSearchMetadataContextInfo>()
            {
                new PackageSearchMetadataContextInfo()
                {
                    Identity = new PackageIdentity("NuGet.org", new NuGetVersion("1.0")),
                    PrefixReserved = true
                }
            };

            var searchResult = new SearchResultContextInfo(packageSearchMetadata, new Dictionary<string, LoadingStatus> { { "Search", LoadingStatus.Loading } }, false);

            searchService.Setup(x =>
                x.SearchAsync(
                    It.IsAny<IReadOnlyCollection<IProjectContextInfo>>(),
                    It.IsAny<IReadOnlyCollection<PackageSource>>(),
                    It.IsAny<string>(),
                    It.IsAny<SearchFilter>(),
                    It.IsAny<NuGet.VisualStudio.Internal.Contracts.ItemFilter>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<SearchResultContextInfo>(searchResult));

            using (var localFeedDir = TestDirectory.Create()) // local feed
            {
                // create test package
                var pkgId = new PackageIdentity("nuget.lpsm.test", new NuGetVersion(0, 0, 1));
                var pkg = new SimpleTestPackageContext(pkgId.Id, pkgId.Version.ToNormalizedString());
                await SimpleTestPackageUtility.CreatePackagesAsync(localFeedDir.Path, pkg);

                // local test source
                var localUri = new Uri(localFeedDir.Path, UriKind.Absolute);
                var localSource = new PackageSource(localUri.ToString(), "LocalSource");

                var sourceRepositoryProvider = TestSourceRepositoryUtility.CreateSourceRepositoryProvider(new[] { localSource });
                var repositories = sourceRepositoryProvider.GetRepositories();

                var context = new PackageLoadContext(false, uiContext);

                var packageFeed = new MultiSourcePackageFeed(repositories, logger: null, telemetryService: null);
                var loader = await PackageItemLoader.CreateAsync(context, new List<PackageSource> { localSource }, NuGet.VisualStudio.Internal.Contracts.ItemFilter.All, searchService.Object, "nuget");

                // Act
                await loader.LoadNextAsync(null, CancellationToken.None);
                var results = loader.GetCurrent();

                // Assert
                Assert.Single(results);
                Assert.NotNull(results.First().PackageReader);
            }
        }
    }
}
