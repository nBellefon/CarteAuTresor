using CarteAuTresor.Model;
using System.Drawing;
using Point = CarteAuTresor.Model.Point;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AventurierAvanceNord()
        {
            var carte = new Carte(5, 5);
            var aventurier = new Aventurier
            {
                Position = new Point() { AxeX = 2, AxeY = 2 },
                Orientation = "N"
            };

            aventurier.Avancer(carte);

            Assert.AreEqual(2, aventurier.Position.AxeX);
            Assert.AreEqual(1, aventurier.Position.AxeY);
        }

        [TestMethod]
        public void AventurierChangeOrientation()
        {

            var aventurier = new Aventurier()
            {
                Orientation = "N"
            };

            aventurier.ChangerOrientation('G');

            Assert.AreEqual("O", aventurier.Orientation);

            aventurier.ChangerOrientation('D');

            Assert.AreEqual("N", aventurier.Orientation);

        }

        [TestMethod]
        public void AventurierCollecteTresor()
        {
            var carte = new Carte(5, 5);

            carte.Tresors.Add(new Tresor() { AxeX = 2, AxeY = 2, Quantite = 1 });

            var aventurier = new Aventurier
            {
                Position = new Point() { AxeX = 2, AxeY = 2 }
            };

            aventurier.RecupTresors(carte);

            Assert.AreEqual(1, aventurier.Tresors);
            Assert.AreEqual(0, carte.Tresors.Count);
        }


        [TestMethod]
        public void AventurierAvanceDansMontagne()
        {
            var carte = new Carte(5, 5);

            carte.Montagnes.Add(new Point() { AxeX = 2, AxeY = 3 });

            var aventurier = new Aventurier
            {
                Position = new Point() { AxeX = 2, AxeY = 2 },
                Orientation = "S",
                Mouvements = "A"
            };

            aventurier.Avancer(carte);


            Assert.AreEqual(2,aventurier.Position.AxeX);
            Assert.AreEqual(2, aventurier.Position.AxeY);

        }

        [TestMethod]
        public void AventurierAvanceHorsLimite()
        {
            var carte = new Carte(2, 2);

            var aventurier = new Aventurier
            {
                Position = new Point() { AxeX = 0, AxeY = 0 },
                Orientation = "N",
                Mouvements = "A"
            };

            aventurier.Avancer(carte);


            Assert.AreEqual(0, aventurier.Position.AxeX);
            Assert.AreEqual(0, aventurier.Position.AxeY);
        }

        [TestMethod]
        public void AventurierAvanceDansAventurier()
        {
            var carte = new Carte(5, 5);

            carte.Aventuriers.Add(new Aventurier()
            {
                Nom = "Poteau",
                Position = new Point() { AxeX=2, AxeY=3 }
            });

            var aventurier = new Aventurier
            {
                Position = new Point() { AxeX = 2, AxeY = 2 },
                Orientation = "S",
                Mouvements = "A"
            };

            aventurier.Avancer(carte);


            Assert.AreEqual(2, aventurier.Position.AxeX);
            Assert.AreEqual(2, aventurier.Position.AxeY);

        }



    }
}