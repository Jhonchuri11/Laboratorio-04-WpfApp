using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio_04_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listProducts_Click(object sender, RoutedEventArgs e)
        {
            // Creamos la cadena de conexion a base de datos SQL

            try
            {
                string cadenaConnection = "Server=DEV\\SQLEXPRESS; Database=Neptuno; Integrated Security=True;";

                SqlConnection conection = new SqlConnection(cadenaConnection);

                conection.Open();

                SqlCommand command = new SqlCommand("LAB_ListadoProductos", conection);

                command.CommandType = CommandType.StoredProcedure;

                // Llamos nuestra clase productos
                List<Products> listProductos = new List<Products>();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Products products = new Products();
                    products.idproducto = Convert.ToInt32(reader["idproducto"]);
                    products.nombreProducto = reader["idproducto"].ToString();
                    products.idProveedor = Convert.ToInt32(reader["idproducto"]);
                    products.idcategoria = Convert.ToInt32(reader["idproducto"]);
                    products.cantidadPorUnidad = reader["idproducto"].ToString();
                    listProductos.Add(products);
                }

                conection.Close();

                productListado.ItemsSource = listProductos; 

            } catch (Exception ex) {

                MessageBox.Show("No se pudo conectar");

                throw;
            }

            
        }

        private void listcategorias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadenaConnection = "Server=DEV\\SQLEXPRESS; Database=Neptuno; Integrated Security=True;";

                SqlConnection conection = new SqlConnection(cadenaConnection);

                conection.Open();

                SqlCommand command = new SqlCommand("LAB_ListadoCategorias", conection);

                command.CommandType = CommandType.StoredProcedure;

                

                // Llamando al listado de categorias
                List<Categorias> listcategorias = new List<Categorias>();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categorias categoria = new Categorias();
                    categoria.idCategoria = Convert.ToInt32(reader["idcategoria"]);
                    categoria.nombrecategoria = reader["nombrecategoria"].ToString();
                    categoria.descripcion = reader["descripcion"].ToString();
                    categoria.activo = Convert.ToInt32(reader["activo"]);
                    categoria.codCategoria = reader["codcategoria"].ToString();
                    listcategorias.Add(categoria);
                }

                conection.Close();
                productListado.ItemsSource = listcategorias;


            } catch (Exception ex )
            {
                MessageBox.Show("No se pudo conectar");

                throw;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Provedor proveedores = new Provedor();

            proveedores.Show();

        }
    }
}