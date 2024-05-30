using System;

namespace PullingDataFromChildForm
{
    public class RegistrationUtility
    {
        public void SomeMethod()
        {
            using (var detailForm = new DetailForm())
            {
                detailForm.ShowDialog();

                Console.WriteLine($"{detailForm.Name} is {detailForm.Age} years old.");
            }
        }
    }
}
