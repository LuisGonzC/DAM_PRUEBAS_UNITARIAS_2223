using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using gestionBancariaApp;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        [TestMethod]
        // unit test code [TestMethod]
        public void validarMetodoIngreso()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoActual = 0;
            double saldoEsperado = 1500;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
            // Método a probar
            cuenta.realizarIngreso(ingreso);
            // afirmación de la prueba (valor esperado Vs. Valor obtenido)
            saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, "El saldo de la cuenta no es correcto");  
        }

        [TestMethod]
        public void MetodoIngresoNegativo()
        {
            int saldoInicial = 1000;
            int ingreso = -1;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(ingreso);

            Assert.IsTrue(gestionBancaria.ERR_CANTIDAD_INDICADA_NEGATIVA == 1, "El error no se muestra correctamente");
        }

        [TestMethod]
        public void validarMetodoReintegro()
        {
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoActual = 0;
            double saldoEsperado = 500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarReintegro(reintegro);

            saldoActual = cuenta.obtenerSaldo();

            Assert.AreEqual(saldoEsperado, saldoActual, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        public void metodoReintegroNegativo()
        {
            double saldoInicial = 1000;
            int reintegro = -1;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarReintegro(reintegro);

            Assert.IsTrue(gestionBancaria.ERR_CANTIDAD_INDICADA_NEGATIVA == 1, "El error no se muestra correctamente");
        }

        [TestMethod]
        public void reintegroSaldoIns()
        {
            double saldoInicial = 1000;
            int reintegro = 1000;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarReintegro(reintegro);

            Assert.IsTrue(gestionBancaria.ERR_SALDO_INSUFICIENTE == 3, "El error no se muestra correctamente");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void exceptionIngresoNegativo()
        {
            int saldoInicial = 1000;
            int ingreso = -1;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(ingreso);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void exceptionReintegroNegativo()
        {
            double saldoInicial = 1000;
            int reintegro = 0;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void exceptionSaldoInsf()
        {
            double saldoInicial = 1000;
            int reintegro = 1000;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void exceptionFormatoIncorrecto()
        {
            double saldoInicial = 1000;

            string cantidad = "Cien";

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(double.Parse(cantidad));
        }
    }
}
