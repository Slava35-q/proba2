using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using proba2.Models;
using System.Windows;



namespace proba2
{
    public class ExcelDataLoader
    {
        public List<Weapon> LoadWeapons(string filePath)
        {
            var weapons = new List<Weapon>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; // Пропускаем пустые строки

                        var weapon = new Weapon
                        {
                            Name = row.GetCell(0).StringCellValue,
                            Type = row.GetCell(1).StringCellValue,
                            BaseDamage = row.GetCell(2).NumericCellValue // Устанавливаем значение по умолчанию
                        };
                        weapons.Add(weapon);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не найден: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка ввода-вывода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return weapons;
        }

        public List<Mod> LoadMods(string filePath)
        {
            var mods = new List<Mod>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; // Пропускаем пустые строки

                        var mod = new Mod
                        {
                            Name = row.GetCell(0).StringCellValue,
                            DamageMultiplier = row.GetCell(1).NumericCellValue  // Устанавливаем значение по умолчанию
                        };
                        mods.Add(mod);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не найден: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка ввода-вывода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return mods;
        }

        public List<Mob> LoadMobs(string filePath)
        {
            var mobs = new List<Mob>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; // Пропускаем пустые строки

                        var mob = new Mob
                        {
                            Name = row.GetCell(0).StringCellValue,
                            Health = row.GetCell(1).NumericCellValue,
                            Armor = row.GetCell(2).NumericCellValue,
                            DamageDealt = row.GetCell(3).NumericCellValue
                        };
                        mobs.Add(mob);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не найден: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка ввода-вывода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return mobs;
        }

        public List<Mod> LoadMods(string filePath, string weaponType)
        {
            var mods = new List<Mod>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; // Пропускаем пустые строки

                        var modType = row.GetCell(1)?.StringCellValue;

                        if (modType != null && modType.Equals(weaponType, StringComparison.OrdinalIgnoreCase))
                        {
                            var mod = new Mod
                            {
                                Name = row.GetCell(0).StringCellValue,
                                DamageMultiplier = row.GetCell(2).NumericCellValue // Устанавливаем значение по умолчанию
                            };
                            mods.Add(mod);
                        }
                    }
                }

                return mods.Distinct().ToList(); // Убираем дубликаты
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не найден: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return mods;
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка ввода-вывода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return mods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return mods;
            }
        }

    }
}