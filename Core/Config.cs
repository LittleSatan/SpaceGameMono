using System;
using System.IO;

namespace SpaceGameMono.Core
{
    public static class Config
    {
        private static int _width = 1280;

        public static int Width
        {
            get => _width;
            set
            {
                _width = value;
                if (_width < 0)
                    _width = 0;
            }
        }

        private static int _height = 720;

        public static int Height
        {
            get => _height;
            set
            {
                _height = value;
                if (_height < 0)
                    _height = 0;
            }
        }

        public static bool Fullscreen { get; set; } = false;

        private static float _menuScale;

        public static float MenuScale
        {
            get => _menuScale;
            set
            {
                _menuScale = value;
                if (_menuScale < 0)
                    _menuScale = 0;
            }
        }

        private static int _bgm = 1;

        public static int Bgm
        {
            get => _bgm;
            set
            {
                _bgm = value;
                if (_bgm < 0)
                    _bgm = 0;
                if (_bgm > 1)
                    _bgm = 1;
            }
        }

        private static int _se = 1;

        public static int Se
        {
            get => _se;
            set
            {
                _se = value;
                if (_se < 0)
                    _se = 0;
                if (_se > 10)
                    _se = 10;
            }
        }

        private static string GetFolderPath()
        {
            // get path to personal folder:
            // Windows: ...\Documents\
            // Linux:   /home/USER/
            var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // now add an "my games" to the end of the path
            var myGamesDir = Path.Combine(appDataDir, "my games");
            // now add an "spacegame" to the end of the path
            var gameDir = Path.Combine(myGamesDir, "spacegame");
            return gameDir;
        }

        // this method will check if the folder(s) exists.
        // if they dont then this method will create the folder(s)
        public static void CheckAndCreateFolder()
        {
            var gameDir = Config.GetFolderPath();
            if (Directory.Exists(gameDir)) return;
            // if it doesnt exist, create the folder(s)
            Directory.CreateDirectory(gameDir);
        }

        // this method will check for a config file
        // true = config exists, otherwise false
        public static bool CheckForConfig()
        {
            var gameDir = Config.GetFolderPath();
            return (File.Exists(Path.Combine(gameDir, "settings.conf")));
        }

        // this method will try to parse the config file.
        public static void LoadConfig()
        {
            var gameDir = Config.GetFolderPath();
            var configPath = Path.Combine(gameDir, "settings.conf");

            using (StreamReader sw = new StreamReader(configPath))
            {
                while (!sw.EndOfStream)
                {
                    var line = sw.ReadLine();
                    var prot = line.Split(':')[0];
                    var value = line.Split(' ')[1];

                    var t = typeof(Config);

                    try
                    {
                        if (t?.GetProperties() != null)
                        {
                            Type propertyType = t.GetProperty(prot).PropertyType;
                            if (propertyType == typeof(int))
                                t.GetProperty(prot)?.SetValue(null, int.Parse(value));
                            if (propertyType == typeof(float))
                                t.GetProperty(prot)?.SetValue(null, float.Parse(value));
                            if (propertyType == typeof(bool))
                                t.GetProperty(prot)?.SetValue(null, bool.Parse(value));
                            if (propertyType == typeof(string))
                                t.GetProperty(prot)?.SetValue(null, value);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        // saves a nice and readable version of the settings object
        public static void SaveConfig()
        {
            var gameDir = Config.GetFolderPath();
            var configPath = Path.Combine(gameDir, "settings.conf");

            FileStream fs = File.Create(configPath);
            fs.Close();
            using (StreamWriter sw = new StreamWriter(configPath))
            {
                Type type = typeof(Config);
                foreach (var property in type.GetProperties())
                {
                    String write = $"{property.Name}: {property.GetValue(null)}";
                    sw.WriteLine(write);
                }
            }
        }
    }
}