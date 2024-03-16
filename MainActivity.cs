using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Data;

namespace Droid_Calculadora
{
    [Activity(Label = "Droid_Calculadora", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const int maco10 = Resource.Drawable.maco10;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            ImageView img = FindViewById<ImageView>(Resource.Id.imagemMac);
            img.SetImageResource(maco10);

            //Botões para entrada de valores
            Button num1 = (Button)FindViewById(Resource.Id.btn1);
            Button num2 = (Button)FindViewById(Resource.Id.btn2);
            Button num3 = (Button)FindViewById(Resource.Id.btn3);
            Button num4 = (Button)FindViewById(Resource.Id.btn4);
            Button num5 = (Button)FindViewById(Resource.Id.btn5);
            Button num6 = (Button)FindViewById(Resource.Id.btn6);
            Button num7 = (Button)FindViewById(Resource.Id.btn7);
            Button num8 = (Button)FindViewById(Resource.Id.btn8);
            Button num9 = (Button)FindViewById(Resource.Id.btn9);
            Button num0 = (Button)FindViewById(Resource.Id.btn0);

            //Botões para as operações matematicas
            Button equ = (Button)FindViewById(Resource.Id.btnEql);
            Button clr = (Button)FindViewById(Resource.Id.btnDel);
            Button dot = (Button)FindViewById(Resource.Id.btnDot);
            Button div = (Button)FindViewById(Resource.Id.btnDiv);
            Button mul = (Button)FindViewById(Resource.Id.btnMul);
            Button som = (Button)FindViewById(Resource.Id.btnAdd);
            Button sub = (Button)FindViewById(Resource.Id.btnSub);

            //texto para receber a entrada do usuário
            EditText resu = (EditText)FindViewById(Resource.Id.resultText);

            // Testo para exibir o resultado gerado
            EditText resu2 = (EditText)FindViewById(Resource.Id.resultText2);

            //sempre que o texto no EditText mudar a expressão será calculada
            resu.TextChanged += delegate
            {

                if (resu.Text == "")
                {
                    resu2.Text = "";
                }

                string x = resu.Text;
                try
                {
                    //Calcula a expressão
                    double result = Convert.ToDouble(new DataTable().Compute(x, null));
                    resu2.Text = result.ToString();
                }
                catch (Exception)
                {
                    //sem ação
                }
            };

            //define os eventos dos botões de comando
            num1.Click += delegate { resu.Text = resu.Text + num1.Text.ToString(); };
            num2.Click += delegate { resu.Text = resu.Text + num2.Text.ToString(); };
            num3.Click += delegate { resu.Text = resu.Text + num3.Text.ToString(); };
            num4.Click += delegate { resu.Text = resu.Text + num4.Text.ToString(); };
            num5.Click += delegate { resu.Text = resu.Text + num5.Text.ToString(); };
            num6.Click += delegate { resu.Text = resu.Text + num6.Text.ToString(); };
            num7.Click += delegate { resu.Text = resu.Text + num7.Text.ToString(); };
            num8.Click += delegate { resu.Text = resu.Text + num8.Text.ToString(); };
            num9.Click += delegate { resu.Text = resu.Text + num9.Text.ToString(); };
            num0.Click += delegate { resu.Text = resu.Text + num0.Text.ToString(); };

            dot.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != ".")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "/" || x2 == "+")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + dot.Text.ToString();
                    }
                }
            };

            som.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "+")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + som.Text.ToString();
                    }
                }
            };
            sub.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "-")
                    {
                        if (x2 == "+" || x2 == "*" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + sub.Text.ToString();
                    }
                }
            };
            mul.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "*")
                    {
                        if (x2 == "-" || x2 == "+" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + "*";
                    }
                }
            };
            div.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "/")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "+" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + div.Text.ToString();
                    }
                }
            };
            clr.Click += delegate
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(0, l - 1);
                    resu.Text = x2;
                    if (x2.Length != 0)
                    {
                        string x3 = x2.Substring(l - 2, 1);
                        if (x3 == "+" || x3 == "-" || x3 == "*" || x3 == "/" || x3 == ".")
                        {
                            try
                            {
                                double result = Convert.ToDouble(new DataTable().Compute(x.Substring(0, l - 2), null));
                                resu2.Text = result.ToString();
                            }
                            catch (Exception)
                            {
                                //
                            }
                        }
                    }
                }
            };
            equ.Click += delegate
            {
                if (resu2.Text != "")
                {
                    resu.Text = resu2.Text;
                    resu2.Text = "";
                }
            };

        }

        private void Resu_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

