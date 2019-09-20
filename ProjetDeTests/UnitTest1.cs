using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelObjet;

namespace ProjetDeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValiderTest()
        {
            // Le nombre de jours d'achat est < à 30 jours
            const int nbJours1 = 25;
            Assert.AreEqual(true, Condition.Valider(nbJours1));

            // Le nombre de jours d'achat est > à 30 jours
            const int nbJours2 = 35;
            Assert.AreEqual(false, Condition.Valider(nbJours2));
        }

        [TestMethod()]
        public void CalculerMontantMaxTest()
        {
            // Pour la catégorie livre
            int livre1 = Condition.CalculerMontantMax("Livre");
            Assert.AreEqual(30, livre1);

            // Pour la catégorie jouet
            int jouet1 = Condition.CalculerMontantMax("Jouet");
            Assert.AreEqual(50, jouet1);

            // Pour la catégorie informatique
            int info1 = Condition.CalculerMontantMax("Informatique");
            Assert.AreEqual(1000, info1);

        }

        [TestMethod()]
        public void CalculerMontantRembourseTest()
        {
            // Un livre achété 24 euros depuis 15 jours avec un état "Très abimé" en étant non membre


            // Un livre achété 24 euros depuis 15 jours avec un état "Bon" en étant membre

        }

        [TestMethod()]
        public void CalculerReductionMembreTest()
        {
            // Il est membre
            double membre1 = Condition.CalculerReductionMembre(true);
            Assert.AreEqual(0, membre1);

            // Il n'est pas membre
            double membre2 = Condition.CalculerReductionMembre(false);
            Assert.AreEqual(0.2, membre2);


        }

        [TestMethod()]
        public void CalculerReductionTest()
        {
            // Pour un état "bon"
            double etat1 = Condition.CalculerReduction("Bon");
            Assert.AreEqual(0.1, etat1);


            // Pour un état "abimé"
            double etat2 = Condition.CalculerReduction("Abimé");
            Assert.AreEqual(0.3, etat2);


        }
    }
}
