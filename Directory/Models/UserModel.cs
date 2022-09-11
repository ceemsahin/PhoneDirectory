using Directory.Enums;
using System.ComponentModel.DataAnnotations;

namespace Directory.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "İsim-Soyisim alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girmelisiniz")]
        [Display(Name = "İsim Soyisim")]
        public string? NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz")]
        [Display(Name = "Kategori")]
        public Category category { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş geçilemez")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
