using proba2.Models;
using proba2;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void OnWeaponButtonClick(object sender, RoutedEventArgs e)
        {
            var loader = new ExcelDataLoader();
            var weapons = loader.LoadWeapons(@"\\iscsi\profstud\VasinVA\Desktop\Weapon.xlsx");
            WeaponsListBox.ItemsSource = weapons;

        }

        private void OnMobButtonClick(object sender, RoutedEventArgs e)
        {
            var loader = new ExcelDataLoader();
            var mobs = loader.LoadMobs(@"\\iscsi\profstud\VasinVA\Desktop\Mobs.xlsx");
            MobsListBox.ItemsSource = mobs;
        }

        private void OnModButtonClick(object sender, RoutedEventArgs e)
        {
            var loader = new ExcelDataLoader();
            var mods = loader.LoadMods(@"\\iscsi\profstud\VasinVA\Desktop\Mods.xlsx");
            ModsListBox.ItemsSource = mods;
        }

        private void OnCalculateDamageClick(object sendzer, RoutedEventArgs e)
        {
            // Получаем выбранные элементы из списков
            var selectedWeapon = WeaponsListBox.SelectedItem as Weapon;
            var selectedMob = MobsListBox.SelectedItem as Mob;
            var selectedMods = ModsListBox.SelectedItems.Cast<Mod>().ToList();

            // Проверяем, выбраны ли все необходимые элементы
            if (selectedWeapon == null || selectedMob == null || selectedMods.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите оружие, противника и хотя бы один мод.");
                return;
            }

            // Вычисляем базовый урон
            double totalDamage = selectedWeapon.BaseDamage;

            // Применяем моды
            foreach (var mod in selectedMods)
            {
                totalDamage *= mod.DamageMultiplier; // Увеличиваем урон на множитель мода
            }

            // Учитываем броню противника (простой расчет)
            double effectiveDamage = CalculateEffectiveDamage(totalDamage, selectedMob.Armor);

            // Выводим результат
            MessageBox.Show($"Итоговый урон по {selectedMob.Name}: {effectiveDamage}");
        }

        private double CalculateEffectiveDamage(double damage, double armor)
        {
            // Простой расчет эффективного урона с учетом брони
            if (armor <= 0) return damage;

            double damageReduction = armor / (armor + 300); // Пример формулы для расчета урона с учетом брони
            return damage * (1 - damageReduction);
        }

        private void ModsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}