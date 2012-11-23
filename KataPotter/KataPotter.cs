using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class KataPotter : IKataPotter 
    {
        const int PRECIO_LIBRO = 8;
        const int COLECCION_POTTER = 7;
        const double DESCUENTO_2 = 0.05;
        const double DESCUENTO_3 = 0.10;
        const double DESCUENTO_4 = 0.15;
        const double DESCUENTO_5 = 0.20;
        const double DESCUENTO_6 = 0.30;
        const double DESCUENTO_7 = 0.45;

        public double DamePrecio(int[,] pedido) {
            int tamanioCarro = 0;
            double precioFinal = 0;
            double precioPaquete = 0;
            double descuento = 0;

            List<int> carro = LlenaCarroDesdePedido(pedido);

            while (ExistenElementosEnCarro(carro)) {
                descuento = DameDescuento(carro);
                precioPaquete = DamePrecioPaquete(carro, descuento);
                precioFinal = precioFinal + precioPaquete;
                tamanioCarro = carro.Count;
                EliminaElementosPagados(carro, tamanioCarro);
            }

            return precioFinal;
        }

        private void EliminaElementosPagados(List<int> carro, int tamanioCarro)
        {
            for (int i = tamanioCarro - 1; i >= 0; i--)
            {
                if (carro[i] == 1)
                    carro.Remove(carro[i]);
                else
                    carro[i]--;
            }
        }

        private double DamePrecioPaquete(List<int> carro, double descuento)
        {
            return PRECIO_LIBRO * carro.Count() * (1 - descuento);
        }

        private double DameDescuento(List<int> carro)
        {
            switch (carro.Count)
            {
                case 7:
                    return DESCUENTO_7;
                case 6:
                    return DESCUENTO_6;
                case 5:
                    return DESCUENTO_5;
                case 4:
                    return DESCUENTO_4;
                case 3:
                    return DESCUENTO_3;
                case 2:
                    return DESCUENTO_2;
                default:
                    return 0;
            }
        }

        private bool ExistenElementosEnCarro(List<int> carro)
        {
            return carro.Count > 0;
        }

        private List<int> LlenaCarroDesdePedido(int[,] pedido)
        {
            List<int> carro = new List<int>();
            for (int i = 0; i < COLECCION_POTTER; i++)
            {
                if (pedido[i, 0] == 1)
                {
                    carro.Add(pedido[i, 1]);
                }
            }
            return carro;
        }
    }
}
