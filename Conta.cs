using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PIROCAAA
namespace OiMundo
{
    class Conta
    {
       public double saldo;
       public String titular;
       public int numero;
    public void Deposita(double valor)
        {
            this.saldo += valor;
        }
    public bool Saca(double valor)
        {
            if(this.saldo >= valor)
            {
                this.saldo -= valor;
                return true;
            }
            return false;
        }
        
    }
}
