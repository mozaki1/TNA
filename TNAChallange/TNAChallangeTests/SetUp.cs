namespace TNAChallangeTests
{
    using Moq;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Threading.Tasks;
    using TNAChallange.Core.Interfaces;

    /// <summary>
    /// Defines the <see cref="SetUp" />.
    /// Generates Mock API Data
    /// </summary>
    public class SetUp
    {
        /// <summary>
        /// Defines the _iRepositoryMock.
        /// </summary>
        private readonly Mock<IRepository> _iRepsitoryMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetUp"/> class.
        /// </summary>
        /// <param name="iRepositoryMock">The iRepositoryMock<see cref="Mock{IRepository}"/>.</param>
        public SetUp(Mock<IRepository> iRepsitoryMock)
        {
            this._iRepsitoryMock = iRepsitoryMock;
          
        }

        public void JsonString(Func<string> testfunc)
        {
           

            _iRepsitoryMock.Setup((json) =>  json.GetById(It.IsAny<string>())).ReturnsAsync(testfunc);

        }

        public static string TestOneTitleNotNullMockJson()
        {
            var JSONstr = @"{
              'accessRegulation': null,
              'accruals': null,
              'accumulationDates': null,
              'administrativeBackground': null,
              'appraisalInformation': null,
              'arrangement': null,
              'batchId': null,
              'copiesInformation': [],
              'corporateNames': [],
              'creatorName': [
                {
                                'description': null,
                  'endDate': 0,
                  'firstName': null,
                  'preTitle': null,
                  'startDate': 0,
                  'surname': null,
                  'title': null,
                  'xReferenceId': null,
                  'xReferenceCode': null,
                  'xReferenceName': 'York Musical Theatre Company',
                  'xReferenceType': null,
                  'xReferenceURL': null,
                  'xReferenceDescription': null,
                  'xReferenceSortWord': null
                }
              ],
              'custodialHistory': null,
              'detailedRelatedMaterial': [],
              'detailedSeparatedMaterial': [],
              'dimensions': null,
              'formerReferenceDep': null,
              'formerReferencePro': null,
              'immediateSourceOfAcquisition': [],
              'language': null,
              'legalStatus': 'Not Public Record(s)',
              'links': [],
              'locationOfOriginals': [],
              'mapDesignation': null,
              'mapScaleNumber': 0,
              'note': null,
              'otherReferences': [],
              'people': [],
              'physicalCondition': null,
              'physicalDescriptionExtent': null,
              'physicalDescriptionForm': '2 Files & 1 Item',
              'places': [],
              'publicationNote': [],
              'registryUrl': '',
              'restrictionsOnUse': null,
              'scannedLists': [],
              'subjects': [],
              'unpublishedFindingAids': [],
              'accessConditions': '<p>Open</p>',
              'catalogueId': 0,
              'citableReference': 'MTC/4/2',
              'closureCode': null,
              'closureStatus': null,
              'closureType': null,
              'coveringDates': '2004-2012',
              'coveringFromDate': 20040101,
              'coveringToDate': 20121231,
              'scopeContent': {
                'placeNames': [],
                'description': null,
                'ephemera': null,
                'schema': null
              },
              'digitised': false,
              'heldBy': [
                {
                  'xReferenceId': 'A13529905',
                  'xReferenceCode': '192',
                  'xReferenceName': 'Explore York Libraries & Archives',
                  'xReferenceType': null,
                  'xReferenceURL': null,
                  'xReferenceDescription': null,
                  'xReferenceSortWord': null
                }
              ],
              'id': '48ad391d-a296-4746-b1b4-c39a0ea6e350',
              'isParent': true,
              'catalogueLevel': 6,
              'parentId': 'afcdbd80-b800-46fd-9b63-2d94dd6f34cd',
              'recordOpeningDate': null,
              'referencePart': null,
              'referenceParentId': null,
              'sortKey': '06 0151 0 MTC 04 0 02 0',
              'source': 'A2A',
              'title': 'Titanic Production',
            }";
            return JSONstr;
        }
        public static string TestTowTitleNullScopeContentDescriptionNotNullMockJson()
        {
            var JSONstr = @"{
            'accessRegulation': null,
            'accruals': null,
            'accumulationDates': null,
            'administrativeBackground': null,
            'appraisalInformation': null,
            'arrangement': null,
            'batchId': null,
            'copiesInformation': [],
            'corporateNames': [],
            'creatorName': [],
            'custodialHistory': null,
            'detailedRelatedMaterial': [],
            'detailedSeparatedMaterial': [],
            'dimensions': null,
            'formerReferenceDep': null,
            'formerReferencePro': null,
            'immediateSourceOfAcquisition': [],
            'language': null,
            'legalStatus': null,
            'links': [],
            'locationOfOriginals': [],
            'mapDesignation': null,
            'mapScaleNumber': 0,
            'note': null,
            'otherReferences': [
                {
                    'key': 0,
                    'value': '21023 Titanic  Fund'
                }
            ],
            'people': [],
            'physicalCondition': null,
            'physicalDescriptionExtent': null,
            'physicalDescriptionForm': null,
            'places': [],
            'publicationNote': [],
            'registryUrl': null,
            'restrictionsOnUse': null,
            'scannedLists': [],
            'subjects': [],
            'unpublishedFindingAids': [],
            'accessConditions': null,
            'catalogueId': 0,
            'citableReference': 'D/WW',
            'closureCode': null,
            'closureStatus': null,
            'closureType': null,
            'coveringDates': '1912-59',
            'coveringFromDate': 19120101,
            'coveringToDate': 19591231,
            'scopeContent': {
                'placeNames': [],
                'description': 'minute books, cash book, accounts, registers of payments and beneficiaries',
                'ephemera': null,
                'schema': null
            },
            'digitised': false,
            'heldBy': [
                {
                    'xReferenceId': 'A13530251',
                    'xReferenceCode': '43',
                    'xReferenceName': 'Southampton Archives Office',
                    'xReferenceType': null,
                    'xReferenceURL': null,
                    'xReferenceDescription': null,
                    'xReferenceSortWord': null
                }
            ],
            'id': 'N13759454',
            'isParent': false,
            'catalogueLevel': 0,
            'parentId': 'F111295',
            'recordOpeningDate': null,
            'referencePart': null,
            'referenceParentId': null,
            'sortKey': 'N713759454 0',
            'source': 'NRA',
            'title': null
        }";
            return JSONstr;
        }

        public static string TestThreeTitleNullSDNullCitableReferenceNotNullMockJson()
        {
            var JSONstr = @"{
            'accessRegulation': null,
            'accruals': null,
            'accumulationDates': null,
            'administrativeBackground': null,
            'appraisalInformation': null,
            'arrangement': null,
            'batchId': null,
            'copiesInformation': [],
            'corporateNames': [],
            'creatorName': [],
            'custodialHistory': null,
            'detailedRelatedMaterial': [],
            'detailedSeparatedMaterial': [],
            'dimensions': null,
            'formerReferenceDep': null,
            'formerReferencePro': null,
            'immediateSourceOfAcquisition': [],
            'language': null,
            'legalStatus': null,
            'links': [],
            'locationOfOriginals': [],
            'mapDesignation': null,
            'mapScaleNumber': 0,
            'note': null,
            'otherReferences': [
                {
                    'key': 0,
                    'value': '21023 Titanic  Fund'
                }
            ],
            'people': [],
            'physicalCondition': null,
            'physicalDescriptionExtent': null,
            'physicalDescriptionForm': null,
            'places': [],
            'publicationNote': [],
            'registryUrl': null,
            'restrictionsOnUse': null,
            'scannedLists': [],
            'subjects': [],
            'unpublishedFindingAids': [],
            'accessConditions': null,
            'catalogueId': 0,
            'citableReference': 'D/WW',
            'closureCode': null,
            'closureStatus': null,
            'closureType': null,
            'coveringDates': '1912-59',
            'coveringFromDate': 19120101,
            'coveringToDate': 19591231,
            'scopeContent': {
                'placeNames': [],
                'description': null,
                'ephemera': null,
                'schema': null
            },
            'digitised': false,
            'heldBy': [
                {
                    'xReferenceId': 'A13530251',
                    'xReferenceCode': '43',
                    'xReferenceName': 'Southampton Archives Office',
                    'xReferenceType': null,
                    'xReferenceURL': null,
                    'xReferenceDescription': null,
                    'xReferenceSortWord': null
                }
            ],
            'id': 'N13759454',
            'isParent': false,
            'catalogueLevel': 0,
            'parentId': 'F111295',
            'recordOpeningDate': null,
            'referencePart': null,
            'referenceParentId': null,
            'sortKey': 'N713759454 0',
            'source': 'NRA',
            'title': null
        }";
            return JSONstr;
        }

        public static string ALLNullMockJson()
        {
            var JSONstr = @"{
            'accessRegulation': null,
            'accruals': null,
            'accumulationDates': null,
            'administrativeBackground': null,
            'appraisalInformation': null,
            'arrangement': null,
            'batchId': null,
            'copiesInformation': [],
            'corporateNames': [],
            'creatorName': [],
            'custodialHistory': null,
            'detailedRelatedMaterial': [],
            'detailedSeparatedMaterial': [],
            'dimensions': null,
            'formerReferenceDep': null,
            'formerReferencePro': null,
            'immediateSourceOfAcquisition': [],
            'language': null,
            'legalStatus': null,
            'links': [],
            'locationOfOriginals': [],
            'mapDesignation': null,
            'mapScaleNumber': 0,
            'note': null,
            'otherReferences': [
                {
                    'key': 0,
                    'value': '21023 Titanic  Fund'
                }
            ],
            'people': [],
            'physicalCondition': null,
            'physicalDescriptionExtent': null,
            'physicalDescriptionForm': null,
            'places': [],
            'publicationNote': [],
            'registryUrl': null,
            'restrictionsOnUse': null,
            'scannedLists': [],
            'subjects': [],
            'unpublishedFindingAids': [],
            'accessConditions': null,
            'catalogueId': 0,
            'citableReference': null,
            'closureCode': null,
            'closureStatus': null,
            'closureType': null,
            'coveringDates': '1912-59',
            'coveringFromDate': 19120101,
            'coveringToDate': 19591231,
            'scopeContent': {
                'placeNames': [],
                'description': null,
                'ephemera': null,
                'schema': null
            },
            'digitised': false,
            'heldBy': [
                {
                    'xReferenceId': 'A13530251',
                    'xReferenceCode': '43',
                    'xReferenceName': 'Southampton Archives Office',
                    'xReferenceType': null,
                    'xReferenceURL': null,
                    'xReferenceDescription': null,
                    'xReferenceSortWord': null
                }
            ],
            'id': 'N13759454',
            'isParent': false,
            'catalogueLevel': 0,
            'parentId': 'F111295',
            'recordOpeningDate': null,
            'referencePart': null,
            'referenceParentId': null,
            'sortKey': 'N713759454 0',
            'source': 'NRA',
            'title': null
        }";
            return JSONstr;
        }
    }
}
