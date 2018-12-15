using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace AlbertinaFilhos
{
    class Bd
    {
        //metodo para estabelecer a conexão com o servidor
        public OleDbConnection Conexao()
        {
            String conexao = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|\Bd\BDPastelaria.accdb";
            OleDbConnection link = new OleDbConnection(conexao);
            return link;
        }

        //metodo para retornar dados na base de dados
        public string RetornaDados(String Comando)
        {
            OleDbCommand comando = new OleDbCommand(Comando, Conexao());
            comando.Connection.Open();
            string valor = comando.ExecuteScalar().ToString();
            comando.Connection.Close();
            return valor;
        }
        //metodo para executar um comando na bd
        public void ExecutarComando(String Comando)
        {
            OleDbCommand comando = new OleDbCommand(Comando, Conexao());
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }
        //metodo para retornar o numero de linhas da tabela
        public int RetornaLinhas(String Comando)
        {
            OleDbCommand Cmd = new OleDbCommand(Comando, Conexao());
            OleDbDataAdapter dados = new OleDbDataAdapter(Cmd);
            DataTable tb = new DataTable();
            dados.Fill(tb);
            return tb.Rows.Count;
        }
        //metodo para retornar o numero de linhas da tabela
        public DataTable RetornaTabela(String Comando)
        {
            OleDbCommand Cmd = new OleDbCommand(Comando, Conexao());
            OleDbDataAdapter dados = new OleDbDataAdapter(Cmd);
            DataTable tb = new DataTable();
            dados.Fill(tb);
            return tb;
        }

        //Metodo para verificar se na text box tem somente numeros
        public bool TemLetras(String Str) {
            bool valor = true;
            for (int i = 0; i < Str.Length; i++)
            {
                
                if (Str[i] == '0' || Str[i] == '1' || Str[i] == '2' || Str[i] == '3' || Str[i] == '4' || Str[i] == '5' || Str[i] == '6' || Str[i] == '7' || Str[i] == '8' || Str[i] == '9')
                {
                    valor = false;
                }
                else {
                    valor = true;
                    break;
                }
                
            }

        return valor;
        }
        //Este metodo é semelhante ao anterior, mas este é mais adecuado pra numeros de telefone, visto q os numeros de telefone aceitam caracteres como +, - * ou #
        public bool TemLetrasN(String Str)
        {
            bool valor = false;
            for (int i = 0; i < Str.Length; i++)
            {

                if (Str[i] == '-' || Str[i] == '+' || Str[i] == '*' || Str[i] == '#' || Str[i] == '0' || Str[i] == '1' || Str[i] == '2' || Str[i] == '3' || Str[i] == '4' || Str[i] == '5' || Str[i] == '6' || Str[i] == '7' || Str[i] == '8' || Str[i] == '9')
                {
                    valor = false;
                }
                else
                {
                    valor = true;
                    break;
                }

            }

            return valor;
        }
    }
}
