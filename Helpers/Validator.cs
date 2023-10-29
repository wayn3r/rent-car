namespace RentCar.Helpers
{
    public class Validator
    {
        public static bool ValidateCedula(string cedula)
        {
            int total = 0;
            string valorCedula = cedula.Replace("-", "").Trim();
            int[] digitoMultiplo = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (valorCedula.Length != 11) return false;

            for (int index = 1; index <= valorCedula.Length; index++)
            {
                int result = int.Parse(valorCedula.Substring(index - 1, 1)) * digitoMultiplo[index - 1];

                int value = result < 10 ? result : int.Parse(result.ToString().Substring(0, 1)) + int.Parse(result.ToString().Substring(1, 1));
                
                total += value;
            }

            return total % 10 == 0;
        }

    }
}
