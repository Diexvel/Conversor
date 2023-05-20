namespace Convertidor.Models;

public class Api
{
	public class Valores
	{
		public Moneda Oficial { get; set; }
		public Moneda Blue { get; set; }
		public Moneda Oficial_Euro { get; set; }
		public Moneda Blue_Euro { get; set; }
		public DateTime Last_Update { get; set; }
	}

	public class Moneda
	{
		public decimal Value_Avg { get; set; }
		public decimal Value_Sell { get; set; }
		public decimal Value_Buy { get; set; }
	}
}
