namespace CORE_01_MVC.Models
{
    public class InitDb
    {
        ContextDb Context { get; set; }

        public static void Initialize(ContextDb context)
        {
            if (!context.Pictures.Any())
            {
                context.Pictures.AddRange(
                    new Picture { Name = "Кабинка №1", Path = "the-choyxona-kabinka-1-1.jpg" },
                    new Picture { Name = "Кабинка №2", Path = "the-choyxona-kabinka-2.jpg" },
                    new Picture { Name = "Кабинка №3", Path = "the-choyxona-kabinka-3.jpg" }
                    );
                context.SaveChanges();
            } 
        }
    }
}
