namespace TNAChallangeTests
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using TNAChallange.Core.Interfaces;
    using TNAChallange.Core.Services;
    using Xunit;

    /// <summary>
    /// Defines the <see cref="TNAChallangeUnitTest" />.
    /// </summary>
    public class TNAChallangeUnitTest
    {
        /// <summary>
        /// Defines the NOINFORMATION.
        /// </summary>
        private const string NOINFORMATION = "not sufficient information";

        /// <summary>
        /// Defines the NORECORDFOUND.
        /// </summary>
        private const string NORECORDFOUND = "no record found";

        /// <summary>
        /// Defines the _iRepositoryMock.
        /// </summary>
        private readonly Mock<IRepository> _iRepositoryMock = new Mock<IRepository>();

        /// <summary>
        /// Defines the _iloggerMock.
        /// </summary>
        private readonly Mock<ILogger> _iloggerMock = new Mock<ILogger>();

        /// <summary>
        /// Defines the _iDiscoveryService.
        /// </summary>
        private readonly IDiscoveryService _iDiscoveryService;

        /// <summary>
        /// Defines the _setUp.
        /// </summary>
        private SetUp _setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="TNAChallangeUnitTest"/> class.
        /// </summary>
        public TNAChallangeUnitTest()
        {
            _iDiscoveryService = new DiscoveryService(_iRepositoryMock.Object, _iloggerMock.Object);
            _setUp = new SetUp(_iRepositoryMock);
        }

        /// <summary>
        /// The If_Title_NotNull_ShowTitle.
        /// Given a valid record ID is specified
        /// When the client is run
        /// And the returned record’s ‘title’ is not null
        /// Then the record’s ‘title’ should be displayed.
        /// </summary>
        /// <param name="expectedtitle">The expectedtitle<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Theory]
        [InlineData("Titanic Production")]

        public async Task If_Title_NotNull_ShowTitle(string expectedtitle)
        {

            // Arrange
            var documentid = "test1";
            _setUp.JsonString(SetUp.TestOneTitleNotNullMockJson);
            var document = await _iDiscoveryService.GetDocumentById(documentid);
            // Act
            var actual = _iDiscoveryService.Display(document);
            // Assert
            Assert.NotNull(document);
            Assert.Equal(expectedtitle, actual);
        }

        /// <summary>
        /// If tilte null and scopeContent.description not then show scopeContent.description.
        /// Given a valid record ID is specified
        /// When the client is run
        /// And the returned record’s ‘title’ is null
        /// And the returned record’s ‘scopeContent.description’ is not null
        /// Then the record’s ‘scopeContent.description’ should be displayed.
        /// </summary>
        /// <param name="expectedtitle">.</param>
        /// <param name="expecteddescription">.</param>
        /// <returns>.</returns>
        [Theory]
        [InlineData(null, "minute books, cash book, accounts, registers of payments and beneficiaries")]

        public async Task If_TitleISNull_And_ScopeContentDescriptionISNotNull_ShowScopeContentDescription(string expectedtitle, string expecteddescription)
        {

            // Arrange
            var documentid = "test2";
            _setUp.JsonString(SetUp.TestTowTitleNullScopeContentDescriptionNotNullMockJson);
            var document = await _iDiscoveryService.GetDocumentById(documentid);
            var actualtitle = (string)document["title"];
            // Act
            var actual = _iDiscoveryService.Display(document);
            // Assert
            Assert.NotNull(document);
            Assert.Equal(expectedtitle, actualtitle);
            Assert.Equal(expecteddescription, actual);
        }

        /// <summary>
        /// The If_TitleAndSD_AreNull_AndCReferenceNotNull_ShowCReference.
        /// Given a valid record ID is specified
        /// When the client is run
        /// And the returned record’s ‘title’ is null
        /// And the returned record’s ‘scopeContent.description’ is null
        /// And the returned record’s ‘reference’ is not null
        /// Then the record’s ‘reference’ should be displayed.
        /// </summary>
        /// <param name="expectedtitle">The expectedtitle<see cref="string"/>.</param>
        /// <param name="expecteddescription">The expecteddescription<see cref="string"/>.</param>
        /// <param name="expectedreferencw">The expectedreferencw<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Theory]
        [InlineData(null, null, "D/WW")]

        public async Task If_TitleAndSD_AreNull_AndCReferenceNotNull_ShowCReference(string expectedtitle, string expecteddescription, string expectedreferencw)
        {

            // Arrange
            var documentid = "test3";
            _setUp.JsonString(SetUp.TestThreeTitleNullSDNullCitableReferenceNotNullMockJson);
            var document = await _iDiscoveryService.GetDocumentById(documentid);
            var actualtitle = (string)document["title"];
            var actualdescription = (string)document["scopeContent"]["description"];
            // Act
            var actual = _iDiscoveryService.Display(document);
            // Assert
            Assert.NotNull(document);
            Assert.Equal(expectedtitle, actualtitle);
            Assert.Equal(actualdescription, expecteddescription);
            Assert.Equal(expectedreferencw, actual);
        }

        /// <summary>
        /// The If_AllNull.
        ///Given a valid record ID is specified
        ///When the client is run
        ///And the returned record’s ‘title’ is null
        ///And the returned record’s ‘scopeContent.description’ is null
        ///And the returned record’s ‘reference’ is null
        ///Then a message ‘not sufficient information’ should be displayed.
        /// </summary>
        /// <param name="expectedtitle">The expectedtitle<see cref="string"/>.</param>
        /// <param name="expecteddescription">The expecteddescription<see cref="string"/>.</param>
        /// <param name="expectedreferencw">The expectedreferencw<see cref="string"/>.</param>
        /// <param name="expected">The expected<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Theory]
        [InlineData(null, null, null, NOINFORMATION)]

        public async Task If_AllNull(string expectedtitle, string expecteddescription, string expectedreferencw, string expected)
        {

            // Arrange
            var documentid = "test4";
            _setUp.JsonString(SetUp.ALLNullMockJson);
            var document = await _iDiscoveryService.GetDocumentById(documentid);
            var actualtitle = (string)document["title"];
            var actualdescription = (string)document["scopeContent"]["description"];
            var actualcitablereference = (string)document["citableReference"];
            // Act
            var actual = _iDiscoveryService.Display(document);
            // Assert
            Assert.NotNull(document);
            Assert.Equal(expectedtitle, actualtitle);
            Assert.Equal(actualdescription, expecteddescription);
            Assert.Equal(expectedreferencw, actualcitablereference);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The If_InvalidId
        /// 'no record found’.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <param name="expected">The expected<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Theory]
        [InlineData("Invalid", NOINFORMATION)]
        public async Task If_InvalidId(string id, string expected)
        {

            // Arrange
            string documentid = id;
            _setUp.JsonString(SetUp.ALLNullMockJson);
            var document = await _iDiscoveryService.GetDocumentById(documentid);
            // Act
            var actual = _iDiscoveryService.Display(document);
            // Assert
            Assert.NotNull(document);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The ThrowExcepttionIfNullOrEmptyId.
        /// throws ArgumentNullException for null or empty id.
        /// </summary>
        /// <param name="documentid">The documentid<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ThrowExcepttionIfNullOrEmptyId(string documentid)
        {

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
              _iDiscoveryService.GetDocumentById(documentid)
             );
        }
    }
}
