#region License
// Copyright (c) 2007-2018, FluentMigrator Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using FluentMigrator.Model;

using NUnit.Framework;

namespace FluentMigrator.Tests.Unit.Definitions
{
    [TestFixture]
    public class TableDefinitionTests
    {
        [Test]
        public void WhenDefaultSchemaConventionIsAppliedAndSchemaIsNotSetThenSchemaShouldBeNull()
        {
            var table = new TableDefinition {Name = "Test"};

            table.ApplyConventions(new MigrationConventions());

            Assert.That(table.SchemaName, Is.Null);
        }

        [Test]
        public void WhenDefaultSchemaConventionIsAppliedAndSchemaIsSetThenSchemaShouldNotBeChanged()
        {
            var table = new TableDefinition { Name = "Test", SchemaName = "testschema"};

            table.ApplyConventions(new MigrationConventions());

            Assert.That(table.SchemaName, Is.EqualTo("testschema"));
        }

        [Test]
        public void WhenDefaultSchemaConventionIsChangedAndSchemaIsNotSetThenSetSchema()
        {
            var table = new TableDefinition { Name = "Test" };
            var migrationConventions = new MigrationConventions {GetDefaultSchema = () => "testdefault"};

            table.ApplyConventions(migrationConventions);

            Assert.That(table.SchemaName, Is.EqualTo("testdefault"));
        }
    }
}
