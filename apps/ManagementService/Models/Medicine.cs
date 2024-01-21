using ManagementService.Types;

namespace ManagementService.Models;

public class Medicine
{
  public Medicine(string tradeName, int concentration, string barCode, MedicineType medicineType)
  {
    Name = $"{tradeName} {concentration}";
    BarCode = barCode;
    MedicineType = medicineType;
  }
  public string Name { get; set; }
  public string BarCode { get; set; }
  public MedicineType MedicineType { get; set; }
}
