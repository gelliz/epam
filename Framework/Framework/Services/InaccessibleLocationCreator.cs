using System;
using Framework.Models;

namespace Framework.Services
{
    class InaccessibleLocationCreator
    {
        public static InaccessibleLocation WithInaccessibleLocation()
        {
            return new InaccessibleLocation(TestDataReader.GetTestData("InaccessibleStation"));
        }
    }
}
