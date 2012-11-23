using NUnit.Framework;

namespace KataPotterTest
{
    public class KataPotterTest
    {
        [TestFixture]
        public class No_Compramos_Nada
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido =
                new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Cero()
            {
                Assert.AreEqual(resultado, 0);
            }
        }

        [TestFixture]
        public class Compramos_Un_Libro
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            private double resultado2;
            private double resultado3;

            int[,] pedido = new int[,] { { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido2 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 1 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido3 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 1 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
                resultado2 = SUT.DamePrecio(pedido2);
                resultado3 = SUT.DamePrecio(pedido3);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8);
                Assert.AreEqual(resultado2, 8);
                Assert.AreEqual(resultado3, 8);
            }
        }

        [TestFixture]
        public class Compramos_Dos_O_Mas_Libros_Iguales
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            private double resultado2;
            private double resultado3;

            int[,] pedido = new int[,] { { 1, 3 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido2 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 4 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido3 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 5 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
                resultado2 = SUT.DamePrecio(pedido2);
                resultado3 = SUT.DamePrecio(pedido3);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 3);
                Assert.AreEqual(resultado2, 8 * 4);
                Assert.AreEqual(resultado3, 8 * 5);
            }
        }

        [TestFixture]
        public class Compramos_Dos_Libros_De_Un_Tipo_Y_Uno_De_Otro
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            private double resultado2;
            private double resultado3;

            int[,] pedido = new int[,] { { 1, 2 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido2 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 2 }, { 0, 0 }, { 1, 1 } };
            int[,] pedido3 = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 1, 2 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
                resultado2 = SUT.DamePrecio(pedido2);
                resultado3 = SUT.DamePrecio(pedido3);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, (8 * 2 * 0.95) + 8);
                Assert.AreEqual(resultado2, (8 * 2 * 0.95) + 8);
                Assert.AreEqual(resultado3, (8 * 2 * 0.95) + 8);
            }
        }

        [TestFixture]
        public class Compramos_Tres_Libros_Distintos
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            private double resultado2;
            private double resultado3;
            
            int[,] pedido = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido2 = new int[,] { { 1, 1 }, { 1, 1 }, { 0, 0 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            int[,] pedido3 = new int[,] { { 1, 1 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 1, 1 }, { 0, 0 } };
            
            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
                resultado2 = SUT.DamePrecio(pedido2);
                resultado3 = SUT.DamePrecio(pedido3);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 3 * 0.90);
                Assert.AreEqual(resultado2, 8 * 3 * 0.90);
                Assert.AreEqual(resultado3, 8 * 3 * 0.90);
            }
        }

        [TestFixture]
        public class Compramos_Cuatro_Libros_Distintos
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            
            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 4 * 0.85);
            }
        }

        [TestFixture]
        public class Compramos_Cinco_Libros_Distintos
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 0, 0 }, { 0, 0 }, { 1, 1 } };
            
            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 5 * 0.80);
            }
        }
        
        [TestFixture]
        public class Compramos_Seis_Libros_Distintos
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 0, 0 }, { 1, 1 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 6 * 0.70);
            }
        }

        [TestFixture]
        public class Compramos_La_Coleccion
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado, 8 * 7 * 0.55);
            }
        }

        public class Compramos_7_Del_1_6_Del_2_5_Del_3_4_Del_4_3_Del_5_2_Del_6_1_Del_7
        {
            KataPotter.IKataPotter SUT = new KataPotter.KataPotter();
            private double resultado;
            int[,] pedido = new int[,] { { 1, 7 }, { 1, 6 }, { 1, 5 }, { 1, 4 }, { 1, 3 }, { 1, 2 }, { 1, 1 } };

            [SetUp]
            public void Setup()
            {
                resultado = SUT.DamePrecio(pedido);
            }

            [Test]
            public void Devuelve_Precio()
            {
                Assert.AreEqual(resultado,
                    (8 * 7 * 0.55) + (8 * 6 * 0.70) + (8 * 5 * 0.80) + 
                    (8 * 4 * 0.85) + (8 * 3 * 0.90) + (8 * 2 * 0.95) + (8 * 1 * 1));
            }
        }
    }
}
