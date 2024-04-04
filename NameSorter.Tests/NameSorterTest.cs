using Microsoft.Extensions.DependencyInjection;
using NameSorter.Sort;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Tests
{
    public class NameSorterTest 
    {
        private readonly ISorter _sorter;

        public NameSorterTest()
        {
            _sorter = new Sorter();
        }

        [Fact]
        public void Sort_By_LastName_ShouldBe()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Janet Parsons",
                "Vaughn Lewis"
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Vaughn Lewis");
        }

        [Fact]
        public void Sort_By_LastName_ShouldNotBe()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Janet Parsons",
                "Vaughn Lewis"
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldNotBe("Janet Parsons");
        }

        [Fact]
        public void Sort_By_GivenName_With_Same_LastName()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Vaughn Lewis",
                "Janet Lewis",               
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Janet Lewis");
        }

        [Fact]
        public void Sort_By_GivenName_One_Name_Has_Two_Given_Name_With_Same_LastName()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Vaughn Lewis",
                "Janet Leo Lewis",
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Janet Leo Lewis");
        }

        [Fact]
        public void Sort_By_GivenName_One_Name_Has_Three_Given_Name_With_Same_LastName()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Vaughn Lewis",
                "Janet Leo Marvin Lewis",
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Janet Leo Marvin Lewis");
        }

        [Fact]
        public void Sort_By_Two_GivenName_With_Same_LastName()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Vaughn Hunter Lewis",
                "Janet Leo Lewis",
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Janet Leo Lewis");
        }

        [Fact]
        public void Sort_By_Three_GivenName_With_Same_LastName()
        {
            // Arrange
            var unsortedNames = new List<string>(){
                "Vaughn Hunter Frank Lewis",
                "Janet Leo Marvin Lewis",
            };

            // Act
            var sortedNames = _sorter.SortNames(unsortedNames);

            // Assert
            sortedNames.First().ShouldBe("Janet Leo Marvin Lewis");
        }       
    }
}
