using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.Models
{
	public class RegisterViewModel
	{


		[Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")]
		[EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
		[DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
		[Display(Name = "Pssword")]
		public string Password { get; set; }


		[Required(ErrorMessage = "Yaş alanını boş geçmeyiniz...")]
		[Display(Name = "Age")]
		public byte Age { get; set; }

		[Required(ErrorMessage = "Adres alanını boş geçmeyiniz...")]
		[Display(Name = "Adress")]
		public string Adress { get; set; }

	}
}
