using Microsoft.VisualStudio.TestTools.UnitTesting;
using NI_Fonakolos_játék.Model;

namespace TestProjectAI
{
    [TestClass]
    public class AI_Test
    {
        [TestMethod]
        public void SimpleValueTest()
        {
            BoardMesh testBoard = new BoardMesh();
            for (int i = 0; i < 64; i++)
            {
                testBoard.gameMesh[i].field_owner = 0;
            }
            testBoard.gameMesh[0].field_owner = 4;
            testBoard.gameMesh[1].field_owner = 1;
            testBoard.gameMesh[2].field_owner = 2;
            testBoard.gameMesh[32].field_owner = 4;
            testBoard.gameMesh[33].field_owner = 1;
            testBoard.gameMesh[34].field_owner = 1;
            testBoard.gameMesh[35].field_owner = 2;

            int expected = 32;
            int actual = testBoard.aiStepInd();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ComplexValueTest()
        {
            BoardMesh testBoard = new BoardMesh();
            for (int i = 0; i < 64; i++)
            {
                testBoard.gameMesh[i].field_owner = 0;
            }
            testBoard.gameMesh[0].field_owner = 4;
            testBoard.gameMesh[1].field_owner = 1;
            testBoard.gameMesh[2].field_owner = 1;
            testBoard.gameMesh[3].field_owner = 2;
            testBoard.gameMesh[32].field_owner = 4;
            testBoard.gameMesh[33].field_owner = 1;
            testBoard.gameMesh[34].field_owner = 2;
            testBoard.gameMesh[40].field_owner = 1;
            testBoard.gameMesh[48].field_owner = 1;
            testBoard.gameMesh[56].field_owner = 1;


            int expected = 0;
            int actual = testBoard.aiStepInd();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void MixedValueTest()
        {
            BoardMesh testBoard = new BoardMesh();
            for (int i = 0; i < 64; i++)
            {
                testBoard.gameMesh[i].field_owner = 0;
            }
            testBoard.gameMesh[0].field_owner = 4;
            testBoard.gameMesh[1].field_owner = 1;
            testBoard.gameMesh[2].field_owner = 2;
            testBoard.gameMesh[32].field_owner = 5;
            testBoard.gameMesh[33].field_owner = 1;
            testBoard.gameMesh[34].field_owner = 1;
            testBoard.gameMesh[35].field_owner = 2;

            int expected = 32;
            int actual = testBoard.aiStepInd();

            Assert.AreEqual(expected, actual);
        }
    }
}
