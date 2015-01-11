namespace PullingDataFromChildForm
{
    public class SomeClass
    {
        public void SomeMethod()
        {
            using (var detailForm = new DetailForm())
            {
                detailForm.ShowDialog();

                Name = detailForm.Name;
                Age = detailForm.Age;
            }
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
