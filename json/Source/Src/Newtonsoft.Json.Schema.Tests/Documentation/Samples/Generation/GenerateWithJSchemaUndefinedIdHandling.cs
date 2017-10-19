﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Newtonsoft.Json.Schema.Tests.Documentation.Samples.Generation
{
    [TestFixture]
    public class GenerateWithJSchemaUndefinedIdHandling : TestFixtureBase
    {
        #region Types
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        #endregion

        [Test]
        public void Example()
        {
            #region Usage
            JSchemaGenerator generator = new JSchemaGenerator();

            // types with no defined ID have their type name as the ID
            generator.UndefinedSchemaIdHandling = JSchemaUndefinedIdHandling.UseTypeName;

            JSchema schema = generator.Generate(typeof(Person));
            // {
            //   "id": "Person",
            //   "type": "object",
            //   "properties": {
            //     "name": {
            //       "type": [ "string", "null" ]
            //     },
            //     "age": { "type": "integer" }
            //   },
            //   "required": [ "name", "age" ]
            // }
            #endregion

            Assert.AreEqual(JSchemaType.Object, schema.Type);
            Assert.AreEqual("Newtonsoft.Json.Schema.Tests.Documentation.Samples.Generation.GenerateWithJSchemaUndefinedIdHandling+Person", schema.Id.OriginalString);
        }
    }
}