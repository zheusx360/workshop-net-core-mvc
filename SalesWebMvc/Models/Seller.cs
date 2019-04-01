using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser digitado")]
        [StringLength(100,MinimumLength = 3,ErrorMessage = "O nome deve conter entre 3 e 100 caractéres")]
        public string Name  { get; set; }

        [Required(ErrorMessage = "{0} deve ser digitado")]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "{0} deve ser digitado")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "{0} deve ser digitado")]
        [Range(100.0,50000.0,ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }


        [Display(Name ="Departamento")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
            
        }

    }
}
