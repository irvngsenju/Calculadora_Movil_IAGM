namespace Calculadora_Movil_IAGM;

public partial class Calculadora_movil : ContentPage
{
    double numeroGuardado = 0;
    string operadorActual = " ";
    bool limpiarPantalla = false;
    public Calculadora_movil()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

        
        Button boton = (Button)sender;
        string textoBoton = boton.Text;

       
        switch (textoBoton)
        {
            case "C":
               
                lblPantalla.Text = "0";
                numeroGuardado = 0;
                operadorActual = "";
                limpiarPantalla = false;
                break;

            case "+":
            case "-":
            case "×":
            case "÷":
                
                operadorActual = textoBoton;
                double.TryParse(lblPantalla.Text, out numeroGuardado);
                limpiarPantalla = true;
                break;

            case "=":
                
                double numeroActual = 0;
                double.TryParse(lblPantalla.Text, out numeroActual);
                double resultado = 0;

                if (operadorActual == "+")
                    resultado = numeroGuardado + numeroActual;
                else if (operadorActual == "-")
                    resultado = numeroGuardado - numeroActual;
                else if (operadorActual == "×")
                    resultado = numeroGuardado * numeroActual;
                else if (operadorActual == "÷")
                {
                    if (numeroActual != 0)
                        resultado = numeroGuardado / numeroActual;
                    else
                    {
                        lblPantalla.Text = "Error"; 
                        return;
                    }
                }

                lblPantalla.Text = resultado.ToString();
                numeroGuardado = resultado;
                operadorActual = "";
                limpiarPantalla = true;
                break;

            default:
                
                if (lblPantalla.Text == "0" || limpiarPantalla)
                {
                    lblPantalla.Text = textoBoton;
                    limpiarPantalla = false;
                }
                else
                {
                    lblPantalla.Text += textoBoton;
                }
                break;
        }
        }

}