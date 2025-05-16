using System.Data;

namespace calculator;

partial class Form1 : Form {

    private TextBox visualizador;

    private Button[] botoes = new Button[15];

    private string[] ValoresBTN = {"1", "2", "3", "+", "4", "5", "6", "-", "7", "8", "9", "", "0", "*", "/"};

    private int[] posx = {25, 137, 250, 362};
    private int[] posy = {100, 200, 300, 400};

    public Form1() {
        InitializeComponents();
        visualizador = CriarCaixa();
        int contador = 0;
        int contadorX = 0;
        int contadorY = 0;
        while (contador < 15) {
            if (ValoresBTN[contador] != "") {
                botoes[contador] = CriarBotao(ValoresBTN[contador], posx[contadorX], posy[contadorY]);
            }
            contador++;

            if (contadorX < 3) {
                contadorX++;
            }
            else {
                contadorX = 0;
                contadorY++;
            }
        }
        botoes[11] = new Button();
        botoes[11].Text = "=";
        botoes[11].Size = new System.Drawing.Size(112, 200);
        botoes[11].Location = new System.Drawing.Point(362, 300);
        botoes[11].Click += RespostaBTN;

        this.Controls.Add(botoes[11]);
    }

    public TextBox CriarCaixa() {
        TextBox MinhaTextBox = new TextBox();
        MinhaTextBox.Size = new System.Drawing.Size(450, 24);
        MinhaTextBox.Location = new System.Drawing.Point(25, 20);

        MinhaTextBox.Font = new Font("Arial", 24);

        this.Controls.Add(MinhaTextBox);

        return MinhaTextBox;
    }

    Button CriarBotao(string texto, int posx, int posy) {
        Button MeuBTN = new Button();

        MeuBTN.Text = texto;
        MeuBTN.Size = new System.Drawing.Size(112, 100);
        MeuBTN.Location = new System.Drawing.Point(posx, posy);

        MeuBTN.Click += RespostaBTN;

        this.Controls.Add(MeuBTN);

        return MeuBTN;
    }

    void RespostaBTN(object sender, EventArgs e) {
        Button botaoEntrada = sender as Button;

        if (botaoEntrada.Text == "=") {
            if (!Suporte.VerificarPresencaString(visualizador.Text)) {
                visualizador.Text = "Entrada invalida";
            }
            else {
                DataTable tabela = new DataTable();
                object resultado = tabela.Compute(Suporte.TratarEntrada(visualizador.Text), "");
                visualizador.Text = Convert.ToString(resultado);
            }
        }
        else if (visualizador.Text == "Entrada invalida"){
            visualizador.Text = botaoEntrada.Text;
        }
        else {
            visualizador.Text = visualizador.Text + botaoEntrada.Text;
        }
    }

    void ConstruirBotoes() {

    }
}