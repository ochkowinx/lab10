using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plants;

namespace TestPlants
{
    [TestClass]
    public class PlantTests
    {
        [TestMethod]
        public void TestPlantClone()
        {
            // Arrange
            Plant originalPlant = new Plant("Original Plant", "Green", 123);

            // Act
            Plant clonedPlant = (Plant)originalPlant.Clone();

            // Assert
            Assert.AreEqual(originalPlant, clonedPlant);
            Assert.AreNotSame(originalPlant, clonedPlant);
        }

        [TestMethod]
        public void TestPlantEquals()
        {
            // Arrange
            Plant plant1 = new Plant("Rose", "Red", 456);
            Plant plant2 = new Plant("Rose", "Red", 456);
            Plant plant3 = new Plant("Sunflower", "Yellow", 789);

            // Act & Assert
            Assert.IsTrue(plant1.Equals(plant2));
            Assert.IsFalse(plant1.Equals(plant3));
        }
    }

    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TestTreeClone()
        {
            // Arrange
            Tree originalTree = new Tree("Oak", "Brown", 10.5, 567);

            // Act
            Tree clonedTree = (Tree)originalTree.Clone();

            // Assert
            Assert.AreEqual(originalTree, clonedTree);
            Assert.AreNotSame(originalTree, clonedTree);
        }

        [TestMethod]
        public void TestTreeEquals()
        {
            // Arrange
            Tree tree1 = new Tree("Oak", "Brown", 10.5, 567);
            Tree tree2 = new Tree("Oak", "Brown", 10.5, 567);
            Tree tree3 = new Tree("Maple", "Yellow", 8.0, 890);

            // Act & Assert
            Assert.IsTrue(tree1.Equals(tree2));
            Assert.IsFalse(tree1.Equals(tree3));
        }
    }

    [TestClass]
    public class FlowerTests
    {
        [TestMethod]
        public void TestFlowerClone()
        {
            // Arrange
            Flower originalFlower = new Flower("Rose", "Red", "Fragrant", 123);

            // Act
            Flower clonedFlower = (Flower)originalFlower.Clone();

            // Assert
            Assert.AreEqual(originalFlower, clonedFlower);
            Assert.AreNotSame(originalFlower, clonedFlower);
        }

        [TestMethod]
        public void TestFlowerEquals()
        {
            // Arrange
            Flower flower1 = new Flower("Rose", "Red", "Fragrant", 123);
            Flower flower2 = new Flower("Rose", "Red", "Fragrant", 123);
            Flower flower3 = new Flower("Tulip", "Pink", "Sweet", 456);

            // Act & Assert
            Assert.IsTrue(flower1.Equals(flower2));
            Assert.IsFalse(flower1.Equals(flower3));
        }
    }

    [TestClass]
    public class RoseTests
    {
        [TestMethod]
        public void TestRoseClone()
        {
            // Arrange
            Rose originalRose = new Rose("Red Rose", "Red", "Fragrant", true, 789);

            // Act
            Rose clonedRose = (Rose)originalRose.Clone();

            // Assert
            Assert.AreEqual(originalRose, clonedRose);
            Assert.AreNotSame(originalRose, clonedRose);
        }

        [TestMethod]
        public void TestRoseEquals()
        {
            // Arrange
            Rose rose1 = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose rose2 = new Rose("Red Rose", "Red", "Fragrant", true, 789);
            Rose rose3 = new Rose("White Rose", "White", "Subtle", false, 987);

            // Act & Assert
            Assert.IsTrue(rose1.Equals(rose2));
            Assert.IsFalse(rose1.Equals(rose3));
        }
    }
}