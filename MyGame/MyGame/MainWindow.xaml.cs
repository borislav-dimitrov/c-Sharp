using MyGameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Player _p1;
        public Monster nmy;
        public Drawing _draw = new Drawing();
        public int rndbg;
        public bool combatState = false;

        public MainWindow()
        {
            InitializeComponent();
            WorldBuilder.buildWorld();
            drawEquippedItems();

            gameScreen.Effect = new BlurEffect();
            charCreation.Visibility = Visibility.Visible;

        }

        #region characterCreation

        private void btnCreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (tbCharName.Text == "")
            {
                MessageBox.Show("Input a name please");
            }
            else
            {
                _p1 = new Player(tbCharName.Text.ToString(), 50, 50, 5, 10, 0, 1);
                updatePlayerInfo(_p1);
                spawnPoint(_p1);
                charCreation.Visibility = Visibility.Hidden;
                gameScreen.Effect = null;
                initHpRegTimer();
            }


        }

        #region spawnPoint

        private void spawnPoint(Player _p1)
        {

            _p1.currentLocation = WorldBuilder.LocationByID(WorldBuilder.LOC_ID_HOME);
            updateLocation(_p1);
            nearbyEnemies(_p1);


        }
        #endregion
        #endregion

        #region updatePlayerInfo

        private void updatePlayerInfo(Player _p1)
        {

            updateReqExpToLevelUp(_p1);
            lblPlayerName.Content = _p1.Name.ToString();
            lblPlayerArmor.Content = _p1.Armor.ToString();
            lblPlayerBlockValue.Content = _p1.BlockValue.ToString();
            lblPlayerMinDMG.Content = _p1.MinDMG.ToString();
            lblPlayerMaxDMG.Content = _p1.MaxDMG.ToString();
            lblPlayerCombatState.Content = combatStance();
            lblPlayerExp.Content = _p1.CurrEXP.ToString() + " / " + _p1.ExpToLvlUp.ToString() + $" ({currExpPercent(_p1)}%)";
            lblPlayerLvl.Content = _p1.Level.ToString();

            if (_p1.CurrHP <= 0)
            {
                lblPlayerHP.Content = "== Dead == ";
                MessageBox.Show("You died! \nYou will be respawned at the starting location with half HP points.");
                respawnAtHome(_p1);
            }
            else
            {
                lblPlayerHP.Content = _p1.CurrHP.ToString();
            }
        }

        #region updateReqExpToLevelUp

        private void updateReqExpToLevelUp(Player _p1)
        {
            if (_p1.CurrEXP >= _p1.ExpToLvlUp)
            {
                double tmpExp = _p1.CurrEXP - _p1.ExpToLvlUp;
                _p1.Level = _p1.Level + 1;
                _p1.ExpToLvlUp = _p1.ExpToLvlUp * 1.5;
                _p1.CurrEXP = Convert.ToInt32(tmpExp);
                lvlUpBonuses();
            }
        }

        private double currExpPercent(Player _p1)
        {
            double percent = _p1.CurrEXP / _p1.ExpToLvlUp;
            percent = percent * 100;
            percent = Math.Round(percent, 2, MidpointRounding.AwayFromZero);
            return percent;
        }

        #region lvlUpBonuses

        private void lvlUpBonuses()
        {
            _p1.MaxHP = _p1.MaxHP + 15;
            _p1.MinDMG = _p1.MinDMG + 1;
            _p1.MaxDMG = _p1.MaxDMG + 1;
            _p1.CurrHP = _p1.MaxHP;
        }
        #endregion
        #endregion

        #region combatStance

        private string combatStance()
        {
            string combatstate;
            if (combatState)
            {
                combatstate = "In combat";
                return combatstate;
            }
            else 
            {
                combatstate = "Out of combat.";
                return combatstate;
            }
        }
        #endregion

        #endregion

        #region updateEnemyInfo

        private void updateEnemyInfo()
        {
            if (nmy != null)
            {
                lblEnemyName.Content = nmy.Name.ToString();
                lblEnemyMinDMG.Content = nmy.MinDMG.ToString();
                lblEnemyMaxDMG.Content = nmy.MaxDMG.ToString();
                lblEnemyLvl.Content = nmy.Level.ToString();
                lblNmyCount.Content = nmy.Quantity.ToString();
                if (nmy.CurrHP <= 0)
                {
                    lblEnemyHP.Content = " == Dead == ";
                }
                else
                {
                    lblEnemyHP.Content = nmy.CurrHP.ToString();
                }
            }



        }
        #endregion

        #region respawnAtHome

        private void respawnAtHome(Player _p1)
        {

            _p1.currentLocation = WorldBuilder.LocationByID(WorldBuilder.LOC_ID_HOME);
            _p1.IsAlive = true;
            _p1.CurrHP = _p1.MaxHP / 2;
            updatePlayerInfo(_p1);
            updateLocation(_p1);


        }
        #endregion

        #region updateLocationInfo

        private void updateLocation(Player _p1)
        {
            lblLocation.Content = _p1.currentLocation.Name.ToString() + " - " +
                _p1.currentLocation.Description.ToString();
            drawLocation(_p1);
            movement(_p1);
            //nearbyEnemies(_p1);
        }


        #region drawLocation

        private void drawLocation(Player _p1)
        {
            Drawing drawing = new Drawing();
            drawing.drawCurrLocation(drawScene, _p1.currentLocation);
        }
        #endregion

        #endregion

        #region showMap

        private void showMap()
        {
            _draw.drawMap(drawScene, _p1);
        }
        #endregion

        #region Movement

        private void movement(Player _p1)
        {
            checkMovementKeys(_p1);
        }

        #region moveUP

        private void moveUp(Player _p1)
        {
            _p1.currentLocation = _p1.currentLocation.Up;
            btnMoveUp.Visibility = Visibility.Hidden;
        }

        private void checkUpKey(Player _p1)
        {
            if (_p1.currentLocation.Up != null)
            {
                btnMoveUp.Visibility = Visibility.Visible;
                btnMoveUp.Content = "Go to " + _p1.currentLocation.Up.Name.ToString();
            }
            else
            {
                btnMoveUp.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region moveLeft

        private void moveLeft(Player _p1)
        {
            _p1.currentLocation = _p1.currentLocation.Left;
            btnMoveLeft.Visibility = Visibility.Hidden;
        }

        private void checkLeftKey(Player _p1)
        {
            if (_p1.currentLocation.Left != null)
            {
                btnMoveLeft.Visibility = Visibility.Visible;
                btnMoveLeft.Content = "Go to " + _p1.currentLocation.Left.Name.ToString();
            }
            else
            {
                btnMoveLeft.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region moveRight

        private void moveRight(Player _p1)
        {
            _p1.currentLocation = _p1.currentLocation.Right;
            btnMoveRight.Visibility = Visibility.Hidden;
        }

        private void checkRightKey(Player _p1)
        {
            if (_p1.currentLocation.Right != null)
            {
                btnMoveRight.Visibility = Visibility.Visible;
                btnMoveRight.Content = "Go to " + _p1.currentLocation.Right.Name.ToString();
            }
            else
            {
                btnMoveRight.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region moveDown

        private void moveDown(Player _p1)
        {
            _p1.currentLocation = _p1.currentLocation.Down;
            btnMoveDown.Visibility = Visibility.Hidden;
        }

        private void checkDownKey(Player _p1)
        {
            if (_p1.currentLocation.Down != null)
            {
                btnMoveDown.Visibility = Visibility.Visible;
                btnMoveDown.Content = "Go to " + _p1.currentLocation.Down.Name.ToString();
            }
            else
            {
                btnMoveDown.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region checkMovementKeys

        private void checkMovementKeys(Player _p1)
        {
            checkUpKey(_p1);
            checkLeftKey(_p1);
            checkRightKey(_p1);
            checkDownKey(_p1);
        }
        #endregion

        #region hideMovementKeys

        private void hideMovementDuringMap()
        {
            btnMoveUp.Visibility = Visibility.Hidden;
            btnMoveLeft.Visibility = Visibility.Hidden;
            btnMoveRight.Visibility = Visibility.Hidden;
            btnMoveDown.Visibility = Visibility.Hidden;
        }
        #endregion

        #endregion

        #region buttonFunctions

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            hideMovementDuringMap();
            showMap();
        }

        private void drawScene_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draw.clearCanvas(drawScene);
            updateLocation(_p1);
            movement(_p1);
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            moveUp(_p1);
            updateLocation(_p1);
            nearbyEnemies(_p1);

        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            moveLeft(_p1);
            updateLocation(_p1);
            nearbyEnemies(_p1);

        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            moveRight(_p1);
            updateLocation(_p1);
            nearbyEnemies(_p1);

        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            moveDown(_p1);
            updateLocation(_p1);
            nearbyEnemies(_p1);

        }

        private void btnFight_Click(object sender, RoutedEventArgs e)
        {
            if (lbNearbyEnemies.Items.Count == -1)
            {
                gameScreen.Effect = new BlurEffect();
                MessageBox.Show("There are no enemies nearby!");
            }
            else if (lbNearbyEnemies.Items.Count > 0)
            {
                combat(_p1);
            }
            gameScreen.Effect = null;
        }

        private void btnHack_Click(object sender, RoutedEventArgs e)
        {

            

            _p1.CurrHP = _p1.MaxHP;
            updatePlayerInfo(_p1);
            nmy = enemySelection();
            nmy.Quantity = 15;
            updateEnemyInfo();
        }

        private void btnDrinkPot_Click(object sender, RoutedEventArgs e)
        {
            drinkHPPot();
        }
        #endregion

        #region nearbyEnemies

        private void nearbyEnemies(Player _p1)
        {
            lbNearbyEnemies.Items.Clear();
            foreach (Monster monster in _p1.currentLocation.CreaturesLivingHere)
            {
                lbNearbyEnemies.Items.Add(monster.Name.ToString());
            }
            lbNearbyEnemies.SelectedIndex = 0;
        }
        #endregion

        #region combatSystem

        private Monster enemySelection()
        {
            var currLocation = _p1.currentLocation;
            int nmyID = lbNearbyEnemies.SelectedIndex;
            try
            {
                nmy = currLocation.CreaturesLivingHere[nmyID];   // WorldBuilder.MonsterByID(nmyID);
                return nmy;
            }
            catch
            { return null; }
            
        }

        private void lblNearbyEnemies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nmy = enemySelection();
            updateEnemyInfo();
            previewLootTable();
            updatePlayerInfo(_p1);
        }

        private void combat(Player _p1)
        {
            nmy = enemySelection();
            
            if (nmy.Quantity > 0)
            {
                combatRound(_p1);
            }
            else
            {
                tbCombatLog.Text += $"No more {nmy.Name}'s left..." + Environment.NewLine;
            }


        }

        private void combatRound(Player _p1)
        {
            combatBegin();

            defineFirstAttackerAndBegin(_p1);


        }

        #region defineFirstAttackerAndBegin

        private void defineFirstAttackerAndBegin(Player _p1)
        {
            int coinToss = rndNumber(1, 3);
            tbCombatLog.Text += Environment.NewLine + " {{ Entering combat !!! }}" + Environment.NewLine + Environment.NewLine;
            Thread.Sleep(1);        // !!! put some time between random number generating because it generates same number if there isnt !!!
            if (coinToss == 1)
            {
                playerAtkFirstScenario(_p1);
            }
            else
            {
                playerAtkSecondScenario(_p1);
            }
        }
        #endregion

        #region playerAtkFirstScenario

        private void playerAtkFirstScenario(Player _p1)
        {
            tbCombatLog.Text += $"{_p1.Name} attack first" + Environment.NewLine + Environment.NewLine;
            
        }
        #endregion

        #region playerAtkSecondScenario

        private void playerAtkSecondScenario(Player _p1)
        {
            tbCombatLog.Text += $"{nmy.Name} attack first" + Environment.NewLine + Environment.NewLine;
            choseEnemyAnimationFromRndBG();
            nmyAttacks(_p1);
            //playerAttacks(_p1, nmy);


        }
        #endregion

        #region resetTarget

        public void resetTarget()
        {
            if (nmy.Quantity > 0)
            {
                nmy.IsAlive = true;
                nmy.CurrHP = nmy.MaxHP;
            }
        }
        #endregion

        #region playerAttacks

        private void playerAttacks(Player _p1)
        {
            if (_p1.IsAlive is true && nmy.IsAlive is true)
            {
                playerIsAttacking(_p1);
                Thread.Sleep(1);        // !!! put some time between random number generating because it generates same number if there isnt !!!

                if (nmy.IsAlive)
                {
                    nmyAttacks(_p1);
                    Thread.Sleep(1);        // !!! put some time between random number generating because it generates same number if there isnt !!!
                }

            }

        }

        private int calcPlayerDMG(Player _p1)
        {
            int dmg = rndNumber(_p1.MinDMG, _p1.MaxDMG + 1);
            return dmg;
        }

        private void playerIsAttacking(Player _p1)
        {
            chosePlayerAnimationFromRndBG();
            int dmg = calcPlayerDMG(_p1);
            nmy.CurrHP = nmy.CurrHP - dmg;
            combatLogPlayerDamageDone(_p1, dmg);
            if (nmy.CurrHP <= 0)
            {
                nmy.IsAlive = false;
                nmy.Quantity = nmy.Quantity - 1;
                tbCombatLog.Text += $"{nmy.Name} has died..." + Environment.NewLine;
                tbCombatLog.Text += $"You receive {nmy.ExpReward} exp." + Environment.NewLine;
                _p1.CurrEXP = _p1.CurrEXP + nmy.ExpReward;
                checkAllItemsFromDropTable();
            }
        }

        #region chosePlayerAnimationFromRndBG

        private void chosePlayerAnimationFromRndBG()
        {
            if (rndbg == 1)
            {
                bg1HeroHitEnemy(drawCombat);
            }
            else if (rndbg == 2)
            {
                bg2HeroHitEnemy(drawCombat);
            }
            else if (rndbg == 3)
            {
                bg3HeroHitEnemy(drawCombat);
            }
        }    
        #endregion

        #endregion

        #region nmyAttacks

        private int calcNmyDMG()
        {
            int dmg = rndNumber(nmy.MinDMG, nmy.MaxDMG + 1);
            return dmg;
        }

        private void nmyAttacks(Player _p1)
        {
            int dmg = calcNmyDMG();
            //dmg = dmgReducedByArmor(dmg);
            _p1.CurrHP = _p1.CurrHP - dmg;
            lblPlayerHP.Content = _p1.CurrHP;
            combatLogEnemyDamageDone(_p1, dmg);
            if (_p1.CurrHP <= 0)
            {
                _p1.IsAlive = false;
                tbCombatLog.Text += $"{_p1.Name} has died..." + Environment.NewLine;
                int expLost = _p1.CurrEXP / 4;
                _p1.CurrEXP = _p1.CurrEXP - expLost;
                tbCombatLog.Text += $"You lose {expLost} EXP for dying. " + Environment.NewLine;
            }
        }

        #region choseEnemyAnimationFromRndBG

        private void choseEnemyAnimationFromRndBG()
        {
            if (rndbg == 1)
            {
                bg1EnemyHitHero(drawCombat);
            }
            else if (rndbg == 2)
            {
                bg2EnemyHitHero(drawCombat);
            }
            else if (rndbg == 3)
            {
                bg3EnemyHitHero(drawCombat);
            }
        }
        #endregion

        #region dmgReducedByArmor

        private int dmgReducedByArmor(int dmg)
        {

            if (_p1.Armor > 0)
            {
                double multiplier = _p1.Armor / 25;
                multiplier = multiplier * 0.25;


                return dmg;
            }
            else
            {
                return dmg;
            }
            
        }
        #endregion

        #endregion


        #region combatLogPlayerDamageDone

        private void combatLogPlayerDamageDone(Player _p1, int damage)
        {
            tbCombatLog.Text += $"{_p1.Name} hit {nmy.Name} for {damage} damage... " + Environment.NewLine;
            tbCombatLog.ScrollToEnd();
        }
        #endregion

        #region combatLogEnemyDamageDone

        private void combatLogEnemyDamageDone(Player _p1, int damage)
        {
            tbCombatLog.Text += $"{nmy.Name} hit {_p1.Name} for {damage} damage... " + Environment.NewLine;
            tbCombatLog.ScrollToEnd();
        }
        #endregion

        #region battleGround

        private void choseRandomBG(Canvas drawCombat )
        {
            rndbg = rndNumber(1, 3 + 1);
            
            Thread.Sleep(1);
            if (rndbg == 1)
            {
                battleGround1(drawCombat);
            }
            else if (rndbg == 2)
            {
                battleGround2(drawCombat);
            }
            else if (rndbg == 3)
            {
                battleGround3(drawCombat);
            }
        }

        private void battleGround1(Canvas drawCombat)
        {
            hideMovementDuringMap();
            Drawing drawing = new Drawing();
            drawing.drawBG1(drawCombat, nmy);
            lblLocation.Content = "Battleground1 // -- Fight --";
        }

        #region bg1HeroHitEnemy

        private void bg1HeroHitEnemy(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG1HeroHitEnemy(drawCombat, nmy);
        }
        #endregion

        #region bg1EnemyHitHero

        private void bg1EnemyHitHero(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG1EnemyHitHero(drawCombat, nmy);
        }
        #endregion

        private void battleGround2(Canvas drawCombat)
        {
            hideMovementDuringMap();
            Drawing drawing = new Drawing();
            drawing.drawBG2(drawCombat, nmy);
            lblLocation.Content = "Battleground2 // -- Fight --";
        }

        #region bg2HeroHitEnemy

        private void bg2HeroHitEnemy(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG2HeroHitEnemy(drawCombat, nmy);
        }
        #endregion

        #region bg2EnemyHitHero

        private void bg2EnemyHitHero(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG2EnemyHitHero(drawCombat, nmy);
        }
        #endregion

        private void battleGround3(Canvas drawCombat)
        {
            hideMovementDuringMap();
            Drawing drawing = new Drawing();
            drawing.drawBG3(drawCombat, nmy);
            lblLocation.Content = "Battleground3 // -- Fight --";
        }

        #region bg3HeroHitEnemy

        private void bg3HeroHitEnemy(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG3HeroHitEnemy(drawCombat, nmy);
        }
        #endregion

        #region bg3EnemyHitHero

        private void bg3EnemyHitHero(Canvas drawCombat)
        {
            Drawing drawing = new Drawing();
            drawing.drawBG3EnemyHitHero(drawCombat, nmy);
        }
        #endregion

        #endregion

        #region combatBegin

        private void combatBegin()
        {
            nmy = enemySelection();
            
            combatState = true;
            lbNearbyEnemies.IsEnabled = false;
            btnMap.IsEnabled = false;
            btnFight.IsEnabled = false;
            drawScene.Visibility = Visibility.Hidden;
            drawCombat.Visibility = Visibility.Visible;

            choseRandomBG(drawCombat);
            combatBtnsShow();

            updatePlayerInfo(_p1);
            updateEnemyInfo();
        }
        #endregion

        #region combatEnd

        private void combatEnd()
        {
            

            combatEndingCalculations();
            removingCombatDrawingsAndUpdateLocation();
            
            
        }

        private void combatEndingCalculations()
        {
            resetTarget();

            tbCombatLog.Text += Environment.NewLine + $"[{timeStamp()}] " + " {{ Leaving combat !!! }}" + Environment.NewLine + Environment.NewLine;
            tbCombatLog.ScrollToEnd();

            updateEnemyInfo();
            updatePlayerInfo(_p1);
        }

        private void removingCombatDrawingsAndUpdateLocation()
        {
            combatState = false;
            Drawing drawing = new Drawing();
            drawing.clearCanvas(drawCombat);
            drawCombat.Visibility = Visibility.Hidden;
            drawScene.Visibility = Visibility.Visible;
            updateLocation(_p1);
            combatBtnsHide();
            lbNearbyEnemies.IsEnabled = true;
            btnMap.IsEnabled = true;
            btnFight.IsEnabled = true;
        }
        #endregion

        #region combatButtons

        #region combatBtnsShow

        private void combatBtnsShow()
        {
            btnCombat1.Visibility = Visibility.Visible;
            btnCombat2.Visibility = Visibility.Visible;
            btnCombat3.Visibility = Visibility.Visible;
            btnCombat4.Visibility = Visibility.Visible;            
        }
        #endregion

        #region combatBtnsHide

        private void combatBtnsHide()
        {
            btnCombat1.Visibility = Visibility.Hidden;
            btnCombat2.Visibility = Visibility.Hidden;
            btnCombat3.Visibility = Visibility.Hidden;
            btnCombat4.Visibility = Visibility.Hidden;
        }
        #endregion

        #region buttons

        private async void btnCombat1_Click(object sender, RoutedEventArgs e)
        {
            playerAttacks(_p1);
            updateEnemyInfo();
            lblPlayerHP.Content = _p1.CurrHP;
            if (!_p1.IsAlive)
            {
                MessageBox.Show(_p1.Name + " has lost.", "Combat is ending...");
                combatEnd();
            }
            else if (!nmy.IsAlive)
            {
                MessageBox.Show(nmy.Name + " has lost.", "Combat is ending...");
                combatEnd();
            }

            await disableBtnForXMSecconds(1500, btnCombat1);
            


        }

        private void btnCombat2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCombat3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCombat4_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region btnFunctions

        private async Task disableBtnForXMSecconds(int ms, Button btn)
        {
            btnCombat1.IsEnabled = false;
            await delay(ms);
            btn.IsEnabled = true;
        }

        #endregion

        #endregion

        #endregion

        #region equippedItems

        #region drawEqItems

        private void drawEquippedItems()
        {
            Drawing drawing = new Drawing();
            drawing.drawEquippedITems(drawEqipepd);
        }
        #endregion


        #region button

        private void btnEquip_Click(object sender, RoutedEventArgs e)
        {
            itemEquip();
            tbItemDescription.Clear();
        }
        #endregion

        #region equipFunction

        private void itemEquip()
        {
            string selectedItem = storeInventorySelectedItemName(lbInventory);
            int selectedItemIndex = lbInventory.SelectedIndex;

            if (selectedItem != null)
            {
                string[] splittedItemName = selectedItem.Split('[');
                selectedItem = splittedItemName[0];
                selectedItem = selectedItem.Trim();
                try
                {
                    foreach (Item item in _p1.Inventory)
                    {
                        if (item.ItemName.Equals(selectedItem))
                        {
                            defineTypeOfTheItemBeingEquipped(item, selectedItem, selectedItemIndex);
                        }
                    }
                }
                catch (Exception e)
                {
                    var debugMsg = e.Message;
                    
                }
                
            }
        }
        #endregion

        #region defineTypeOfTheItemBeingEquipped

        private void defineTypeOfTheItemBeingEquipped(Item item, string selectedItem, int selectedItemIndex)
        {
            if (item.ItemType == "Weapon")
            {
                unequipEquippedWeaponIfThereIsOne(item);
                updateEquippedItemForWeaponType(selectedItem);
                updatePlayerStatsBasedOnEquippedWeapon();
                removeItemFromInventoryWhenEquipped(item, selectedItemIndex);
                

            }
            else if (item.ItemType == "Shield")
            {
                unequipEquippedShieldIfThereIsOne(item);
                updateEquippedItemForShieldType(selectedItem);
                updatePlayerStatsBasedOnEquippedShield();
                removeItemFromInventoryWhenEquipped(item,selectedItemIndex);

            }
            else if (item.ItemType == "BodyArmor")
            {
                unequipEquippedBodyArmorIfThereIsOne(item);
                updateEquippedItemForBodyArmorType(selectedItem);
                updatePlayerStatsBasedOnEquippedBodyArmor();
                removeItemFromInventoryWhenEquipped(item,selectedItemIndex);
            }
            else if (item.ItemType == "Helmet")
            {
                unequipEquippedHelmetIfThereIsOne(item);
                updateEquippedItemForHelmetType(selectedItem);
                updatePlayerStatsBasedOnEquippedHelmet();
                removeItemFromInventoryWhenEquipped(item, selectedItemIndex);
            }
            else if (item.ItemType == "Gloves")
            {
                unequipEquippedGlovesIfThereIsOne(item);
                updateEquippedItemForGlovesType(selectedItem);
                updatePlayerStatsBasedOnEquippedGloves();
                removeItemFromInventoryWhenEquipped(item, selectedItemIndex);
            }
            else if (item.ItemType == "Belt")
            {
                unequipEquippedBeltIfThereIsOne(item);
                updateEquippedItemForBeltType(selectedItem);
                updatePlayerStatsBasedOnEquippedBelt();
                removeItemFromInventoryWhenEquipped(item, selectedItemIndex);
            }
            else if (item.ItemType == "Boots")
            {
                unequipEquippedBootsIfThereIsOne(item);
                updateEquippedItemForBootsType(selectedItem);
                updatePlayerStatsBasedOnEquippedBoots();
                removeItemFromInventoryWhenEquipped(item, selectedItemIndex);
            }
            else
            {
                MessageBox.Show("Chose equippable item first.");
            }
        }
        #endregion

        #region updateEquippedItems

        #region updateEquippedItemForWeaponType

        private void updateEquippedItemForWeaponType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.ItemName == selectedItem)
                    {
                        _p1.EquippedWeapon = weapon;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedWeapon

        private void updatePlayerStatsBasedOnEquippedWeapon()
        {
            _p1.MinDMG += _p1.EquippedWeapon.MinDamage;
            _p1.MaxDMG += _p1.EquippedWeapon.MaxDamage;
            lblPlayerMinDMG.Content = _p1.MinDMG;
            lblPlayerMaxDMG.Content = _p1.MaxDMG;
        }
        #endregion
        #endregion

        #region updateEquippedItemForShieldType

        private void updateEquippedItemForShieldType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Shield shield)
                {
                    if (shield.ItemName == selectedItem)
                    {
                        _p1.EquippedShield = shield;
                        
                    }
                }
            }


        }
        #region updatePlayerStatsBasedOnEquippedShield

        private void updatePlayerStatsBasedOnEquippedShield()
        {
            _p1.Armor += _p1.EquippedShield.Armor;
            _p1.BlockValue += _p1.EquippedShield.BlockValue;
            lblPlayerArmor.Content = _p1.Armor;
            lblPlayerBlockValue.Content = _p1.BlockValue;
        }
        #endregion

        #endregion

        #region updateEquippedItemForBodyArmorType

        private void updateEquippedItemForBodyArmorType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is BodyArmor bodyArmor)
                {
                    if (bodyArmor.ItemName == selectedItem)
                    {
                        _p1.EquippedBodyArmor = bodyArmor;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedBodyArmor

        private void updatePlayerStatsBasedOnEquippedBodyArmor()
        {
            _p1.Armor += _p1.EquippedBodyArmor.Armor;
            lblPlayerArmor.Content = _p1.Armor;
            
        }
        #endregion
        #endregion

        #region updateEquippedItemForHelmetType

        private void updateEquippedItemForHelmetType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Helmet helm)
                {
                    if (helm.ItemName == selectedItem)
                    {
                        _p1.EquippedHelmet = helm;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedHelmet

        private void updatePlayerStatsBasedOnEquippedHelmet()
        {
            _p1.Armor += _p1.EquippedHelmet.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region updateEquippedItemForGlovesType

        private void updateEquippedItemForGlovesType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Gloves gloves)
                {
                    if (gloves.ItemName == selectedItem)
                    {
                        _p1.EquippedGloves = gloves;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedGloves

        private void updatePlayerStatsBasedOnEquippedGloves()
        {
            _p1.Armor += _p1.EquippedGloves.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region updateEquippedItemForBeltType

        private void updateEquippedItemForBeltType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Belt belt)
                {
                    if (belt.ItemName == selectedItem)
                    {
                        _p1.EquippedBelt = belt;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedBelt

        private void updatePlayerStatsBasedOnEquippedBelt()
        {
            _p1.Armor += _p1.EquippedBelt.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region updateEquippedItemForBootsType

        private void updateEquippedItemForBootsType(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is Boots boots)
                {
                    if (boots.ItemName == selectedItem)
                    {
                        _p1.EquippedBoots = boots;
                        
                    }
                }
            }


        }

        #region updatePlayerStatsBasedOnEquippedBoots

        private void updatePlayerStatsBasedOnEquippedBoots()
        {
            _p1.Armor += _p1.EquippedBoots.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #endregion

        #region rclickOnEquippedItemFunctions

        private void drawEquipped_MouseRightBtnUp(object sender, MouseButtonEventArgs e)
        {
            drawEquippedItems();
        }

        private void drawEquipped_MouseRightBtnDown(object sender, MouseButtonEventArgs e)
        {
            identifyClickedRectangle(e);
            lbInventory.SelectedIndex = -1;
            
        }

        #region identifyClickedRectangle

        private void identifyClickedRectangle(MouseButtonEventArgs e)
        {
            SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                activeRectangle.Stroke = blackBrush;
                activeRectangle.StrokeThickness = 1.5;

                if (activeRectangle.Name == "drawWeapon")
                {
                    viewInfoForEquippedWeapon();
                }
                else if (activeRectangle.Name == "drawShield")
                {
                    
                    viewInfoForEquippedShield();
                }
                else if (activeRectangle.Name == "drawBodyArmor")
                {
                    viewInfoForEquippedBodyArmor();
                }
                else if (activeRectangle.Name == "drawHelm")
                {
                    viewInfoForEquippedHelmet();
                }
                else if (activeRectangle.Name == "drawGloves")
                {
                    viewInfoForEquippedGloves();
                }
                else if (activeRectangle.Name == "drawBelt")
                {
                    viewInfoForEquippedBelt();
                }
                else if (activeRectangle.Name == "drawBoots")
                {
                    viewInfoForEquippedBoots();
                }
            }
        }
        #endregion

        #region viewInfoForAllItems

        #region viewInfoForEquippedWeapon

        private void viewInfoForEquippedWeapon()
        {
            if (_p1.EquippedWeapon != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Weapon ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedWeapon.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedWeapon.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item MinDMG:   {_p1.EquippedWeapon.MinDamage}" + Environment.NewLine;
                tbItemDescription.Text += $"Item MaxDMG:   {_p1.EquippedWeapon.MaxDamage}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedWeapon.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedWeapon.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Weapon ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedShield

        private void viewInfoForEquippedShield()
        {
            if (_p1.EquippedShield != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Shield ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedShield.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedShield.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedShield.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item BlockValue:   {_p1.EquippedShield.BlockValue}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedShield.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedShield.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Shield ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedBodyArmor

        private void viewInfoForEquippedBodyArmor()
        {
            if (_p1.EquippedBodyArmor != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped BodyArmor ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedShield.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedShield.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedBodyArmor.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedBodyArmor.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedBodyArmor.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped BodyArmor ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedHelmet

        private void viewInfoForEquippedHelmet()
        {
            if (_p1.EquippedHelmet != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Helmet ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedHelmet.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedHelmet.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedHelmet.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedHelmet.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedHelmet.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Helmet ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedGloves

        private void viewInfoForEquippedGloves()
        {
            if (_p1.EquippedGloves != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Gloves ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedGloves.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedGloves.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedGloves.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedGloves.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedGloves.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Gloves ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedBelt

        private void viewInfoForEquippedBelt()
        {
            if (_p1.EquippedBelt != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Belt ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedBelt.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedBelt.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedBelt.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedBelt.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedBelt.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Belt ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #region viewInfoForEquippedBoots

        private void viewInfoForEquippedBoots()
        {
            if (_p1.EquippedBoots != null)
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Boots ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += $"Item Name:   {_p1.EquippedBoots.ItemName}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Description:   {_p1.EquippedBoots.ItemDescription}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Armor:   {_p1.EquippedBoots.Armor}" + Environment.NewLine;
                tbItemDescription.Text += $"Item Durability:   {_p1.EquippedBoots.Durability}" + Environment.NewLine;
                tbItemDescription.Text += $"Required Level:   {_p1.EquippedBoots.RequiredLevel}" + Environment.NewLine;
                tbItemDescription.ScrollToEnd();
            }
            else
            {
                tbItemDescription.Clear();
                tbItemDescription.Text += "=== Equipped Boots ===" + Environment.NewLine + Environment.NewLine;
                tbItemDescription.Text += "=== null ===";
                tbItemDescription.ScrollToEnd();
            }
        }
        #endregion

        #endregion

        #endregion


        #region removeItemFromInventoryWhenEquipped

        private void removeItemFromInventoryWhenEquipped(Item item, int selectedItemIndex)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                refreshInventory();
            }
            else
            {
                _p1.Inventory.RemoveAt(selectedItemIndex);
                refreshInventory();
            }
            
            //lbInventory.Items.RemoveAt(selectedItemIndex);
            //_p1.Inventory.RemoveAt(selectedItemIndex);
            
        }
        #endregion

        #region unequipItems

        #region unequipWeapon

        #region unequipEquippedWeaponIfThereIsOne

        private void unequipEquippedWeaponIfThereIsOne(Item item)
        {
            if (_p1.EquippedWeapon != null)
            {
                updatePlayerStatsWhenWeaponRemoved();

                unequipEquippedWeapon();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedWeapon()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Weapon" && item.ItemName == _p1.EquippedWeapon.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Weapon" && item.ItemName == _p1.EquippedWeapon.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedWeapon);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenWeaponRemoved()
        {
            _p1.MinDMG -= _p1.EquippedWeapon.MinDamage;
            _p1.MaxDMG -= _p1.EquippedWeapon.MaxDamage;
            lblPlayerMinDMG.Content = _p1.MinDMG;
            lblPlayerMaxDMG.Content = _p1.MaxDMG;
        }
        #endregion

        #endregion

        #region unequipShield

        #region unequipEquippedShieldIfThereIsOne

        private void unequipEquippedShieldIfThereIsOne(Item item)
        {
            if (_p1.EquippedShield != null)
            {
                updatePlayerStatsWhenShieldRemoved();

                unequipEquippedShield();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedShield()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Shield" && item.ItemName == _p1.EquippedShield.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Shield" && item.ItemName == _p1.EquippedShield.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedShield);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenShieldRemoved()
        {
            _p1.Armor -= _p1.EquippedShield.Armor;
            _p1.BlockValue -= _p1.EquippedShield.BlockValue;
            lblPlayerArmor.Content = _p1.Armor;
            lblPlayerBlockValue.Content = _p1.BlockValue;
        }
        #endregion

        #endregion

        #region unequipBodyArmor

        #region unequipEquippedBodyArmorIfThereIsOne

        private void unequipEquippedBodyArmorIfThereIsOne(Item item)
        {
            if (_p1.EquippedBodyArmor != null)
            {
                updatePlayerStatsWhenBodyArmorRemoved();

                unequipEquippedBodyArmor();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedBodyArmor()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "BodyArmor" && item.ItemName == _p1.EquippedBodyArmor.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "BodyArmor" && item.ItemName == _p1.EquippedBodyArmor.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedBodyArmor);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenBodyArmorRemoved()
        {
            _p1.Armor -= _p1.EquippedBodyArmor.Armor;
            lblPlayerArmor.Content = _p1.Armor;
            
        }
        #endregion

        #endregion

        #region unequipHelmet

        #region unequipEquippedHelmetIfThereIsOne

        private void unequipEquippedHelmetIfThereIsOne(Item item)
        {
            if (_p1.EquippedHelmet != null)
            {
                updatePlayerStatsWhenHelmetRemoved();

                unequipEquippedHelmet();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedHelmet()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Helmet" && item.ItemName == _p1.EquippedHelmet.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Helmet" && item.ItemName == _p1.EquippedHelmet.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedHelmet);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenHelmetRemoved()
        {
            _p1.Armor -= _p1.EquippedHelmet.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region unequipGloves

        #region unequipEquippedGlovesIfThereIsOne

        private void unequipEquippedGlovesIfThereIsOne(Item item)
        {
            if (_p1.EquippedGloves != null)
            {
                updatePlayerStatsWhenGlovesRemoved();

                unequipEquippedGloves();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedGloves()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Gloves" && item.ItemName == _p1.EquippedGloves.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Gloves" && item.ItemName == _p1.EquippedGloves.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedGloves);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenGlovesRemoved()
        {
            _p1.Armor -= _p1.EquippedGloves.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region unequipBelt

        #region unequipEquippedBeltIfThereIsOne

        private void unequipEquippedBeltIfThereIsOne(Item item)
        {
            if (_p1.EquippedBelt != null)
            {
                updatePlayerStatsWhenBeltRemoved();

                unequipEquippedBelt();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedBelt()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Belt" && item.ItemName == _p1.EquippedBelt.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Belt" && item.ItemName == _p1.EquippedBelt.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedBelt);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenBeltRemoved()
        {
            _p1.Armor -= _p1.EquippedBelt.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #region unequipBoots

        #region unequipEquippedBootsIfThereIsOne

        private void unequipEquippedBootsIfThereIsOne(Item item)
        {
            if (_p1.EquippedBoots != null)
            {
                updatePlayerStatsWhenBootsRemoved();

                unequipEquippedBoots();



                //lbInventory.Items.Add(_p1.EquippedWeapon.ItemName + $" [{_p1.EquippedWeapon.Quantity}]");
            }
        }

        private void unequipEquippedBoots()
        {
            bool itemAlreadyExistInInventory = false;

            foreach (Item item in _p1.Inventory)
            {
                if (item.ItemType == "Boots" && item.ItemName == _p1.EquippedBoots.ItemName)
                {
                    itemAlreadyExistInInventory = true;
                }
            }

            if (itemAlreadyExistInInventory)
            {
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemType == "Boots" && item.ItemName == _p1.EquippedBoots.ItemName)
                    {
                        item.Quantity++;
                        refreshInventory();
                    }
                }
            }
            else
            {
                _p1.Inventory.Add(_p1.EquippedBoots);
                refreshInventory();
            }

        }

        private void updatePlayerStatsWhenBootsRemoved()
        {
            _p1.Armor -= _p1.EquippedBoots.Armor;
            lblPlayerArmor.Content = _p1.Armor;

        }
        #endregion

        #endregion

        #endregion


        #endregion

        #region lootSystem

        private void previewLootTable()
        {
            lbDropTable.Items.Clear();

            try
            {
                foreach (Item item in nmy.DropTable)
                {
                    lbDropTable.Items.Add(item.ItemName + " / " + item.DropChance + "% chance");
                }
                lbDropTable.SelectedItem = 0;
            }
            catch
            { }

        }

        private void checkAllItemsFromDropTable()
        {
            foreach (Item item in nmy.DropTable)
            {
                checkItemFromMonster(item);
            }
        }

        private void checkItemFromMonster(Item item)
        {
            int rolled = rollDice();
            if (item.DropChance >= rolled)
            {
                if (_p1.Inventory.Contains(item))
                {
                    item.Quantity = item.Quantity + 1;
                    
                }
                else
                {
                    _p1.Inventory.Add(item);

                    try
                    {
                        lbInventory.Items.Add(item.ItemName + $" [{item.Quantity}]");
                    }
                    catch
                    { lbInventory.Items.Add(item.ItemName); }
                }
                

                tbCombatLog.Text += $"You received {item.ItemName} ." + Environment.NewLine;
                refreshInventory();
            }
        }

        private int rollDice()
        {
            Random dice = new Random();
            int roll = dice.Next(1, 101);
            Thread.Sleep(1);
            return roll;
        }

        #region refreshInventory

        private void refreshInventory()
        {
            lbInventory.Items.Clear();
            if (_p1.Inventory.Count > 0 )
            {

                foreach (Item item in _p1.Inventory)
                {
                    try
                    {
                        lbInventory.Items.Add(item.ItemName + $" [{item.Quantity}]");
                    }
                    catch
                    { lbInventory.Items.Add(item.ItemName); }
                }
            }
        }
        #endregion


        #region itemInfo



        #region updateItemInfo_on_InventorySelectionCHange

        private void lbInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = storeInventorySelectedItemName(lbInventory);
            if (selectedItem != null)
            {
                string[] splittedItemName = selectedItem.Split('[');
                selectedItem = splittedItemName[0];
                selectedItem = selectedItem.Trim();
                foreach (Item item in _p1.Inventory)
                {
                    if (item.ItemName.Equals(selectedItem))
                    {
                        defineTheTypeOfTheItemInInventory(item, selectedItem);
                    }
                }
            }            
        }
        #endregion

        #region updateItemInfo_on_DropTableSelectionChange

        private void lbDropTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = storeInventorySelectedItemName(lbDropTable);
            if (selectedItem != null)
            {
                string[] splittedItemName = selectedItem.Split('/');
                selectedItem = splittedItemName[0];
                selectedItem = selectedItem.Trim();
                foreach (Item item in nmy.DropTable)
                {
                    if (item.ItemName.Equals(selectedItem))
                    {
                        defineTheTypeOfTheItemInLootTable(item, selectedItem);
                    }
                }
            }
        }
        #endregion




        #region storeInventorySelectedItemName

        private string storeInventorySelectedItemName(ListBox lb)
        {
            string selectedItem;
            if (lb.SelectedIndex != -1)
            {
                selectedItem = lb.SelectedItem.ToString();
                return selectedItem;
            }
            else
            {
                return null;
            }
        }
        #endregion

        // From Inventory


        #region defineTheTypeOfTheItemFromInventory

        private void defineTheTypeOfTheItemInInventory(Item item, string selectedItem)
        {
            if (item.ItemType == "HP Potion")
            {
                updateInfoForHPPotionFromInventory(selectedItem);
            }
            else if (item.ItemType == "Weapon")
            {
                updateInfoForWeaponFromInventory(selectedItem);
            }
            else if (item.ItemType == "Shield")
            {
                updateInfoForShieldFromInventory(selectedItem);
            }
            else if (item.ItemType == "BodyArmor")
            {
                updateInfoForBodyArmorFromInventory(selectedItem);
            }
            else if (item.ItemType == "Helmet")
            {
                updateInfoForHelmetFromInventory(selectedItem);
            }
            else if (item.ItemType == "Gloves")
            {
                updateInfoForGlovesFromInventory(selectedItem);
            }
            else if (item.ItemType == "Belt")
            {
                updateInfoForBeltFromInventory(selectedItem);
            }
            else if (item.ItemType == "Boots")
            {
                updateInfoForBootsFromInventory(selectedItem);
            }
        }
        #endregion

        #region updateInfoForHPPotionFromInventory

        private void updateInfoForHPPotionFromInventory(string selectedItem)
        {

            foreach (Item item in _p1.Inventory)
            {
                if (item is HPPotion potion)
                {
                    if (potion.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += potion.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += potion.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + potion.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }


        }
        #endregion

        #region updateInfoForWeaponFromInventory

        private void updateInfoForWeaponFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += weapon.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += weapon.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Min DMG - " + weapon.MinDamage + Environment.NewLine;
                        tbItemDescription.Text += "Max DMG - " + weapon.MaxDamage + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + weapon.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + weapon.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForShieldFromInventory

        private void updateInfoForShieldFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Shield shield)
                {
                    if (shield.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += shield.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += shield.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + shield.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Block Value - " + shield.BlockValue + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + shield.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + shield.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBodyArmorFromInventory

        private void updateInfoForBodyArmorFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is BodyArmor bodyArmor)
                {
                    if (bodyArmor.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += bodyArmor.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += bodyArmor.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + bodyArmor.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + bodyArmor.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + bodyArmor.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForHelmetFromInventory

        private void updateInfoForHelmetFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Helmet helmet)
                {
                    if (helmet.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += helmet.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += helmet.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + helmet.Armor+ Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + helmet.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + helmet.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForGlovesFromInventory

        private void updateInfoForGlovesFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Gloves gloves)
                {
                    if (gloves.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += gloves.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += gloves.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + gloves.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + gloves.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + gloves.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBeltFromInventory

        private void updateInfoForBeltFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Belt belt)
                {
                    if (belt.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += belt.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += belt.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + belt.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + belt.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + belt.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBootsFromInventory

        private void updateInfoForBootsFromInventory(string selectedItem)
        {
            foreach (Item item in _p1.Inventory)
            {
                if (item is Boots boots)
                {
                    if (boots.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += boots.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += boots.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + boots.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + boots.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + boots.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        // From Loot Table
        #region defineTheTypeOfTheItemInLootTable

        private void defineTheTypeOfTheItemInLootTable(Item item, string selectedItem)
        {
            if (item.ItemType == "HP Potion")
            {
                updateInfoForHPPotionFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Weapon")
            {
                updateInfoForWeaponFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Shield")
            {
                updateInfoForShieldFromLootTable(selectedItem);
            }
            else if (item.ItemType == "BodyArmor")
            {
                updateInfoForBodyArmorFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Helmet")
            {
                updateInfoForHelmetFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Gloves")
            {
                updateInfoForGlovesFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Belt")
            {
                updateInfoForBeltFromLootTable(selectedItem);
            }
            else if (item.ItemType == "Boots")
            {
                updateInfoForBootsFromLootTable(selectedItem);
            }
        }
        #endregion

        #region updateInfoForHPPotionFromLootTable

        private void updateInfoForHPPotionFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is HPPotion potion)
                {
                    if (potion.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += potion.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += potion.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += potion.DropChance + "% chance to drop" + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + potion.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }
        }
        #endregion

        #region updateInfoForWeaponFromLootTable

        private void updateInfoForWeaponFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Weapon weapon)
                {
                    if (weapon.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += weapon.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += weapon.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Min DMG - " + weapon.MinDamage + Environment.NewLine;
                        tbItemDescription.Text += "Max DMG - " + weapon.MaxDamage + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + weapon.Durability + Environment.NewLine;
                        tbItemDescription.Text += weapon.DropChance + "% chance to drop" + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + weapon.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }
        }

        #endregion

        #region updateInfoForShieldFromLootTable

        private void updateInfoForShieldFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Shield shield)
                {
                    if (shield.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += shield.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += shield.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + shield.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Block Value - " + shield.BlockValue + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + shield.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + shield.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBodyArmorFromLootTable

        private void updateInfoForBodyArmorFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is BodyArmor bodyArmor)
                {
                    if (bodyArmor.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += bodyArmor.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += bodyArmor.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + bodyArmor.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + bodyArmor.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + bodyArmor.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForHelmetFromLootTable

        private void updateInfoForHelmetFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Helmet helmet)
                {
                    if (helmet.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += helmet.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += helmet.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + helmet.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + helmet.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + helmet.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForGlovesFromLootTable

        private void updateInfoForGlovesFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Gloves gloves)
                {
                    if (gloves.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += gloves.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += gloves.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + gloves.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + gloves.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + gloves.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBeltFromLootTable

        private void updateInfoForBeltFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Belt belt)
                {
                    if (belt.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += belt.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += belt.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + belt.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + belt.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + belt.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #region updateInfoForBootsFromLootTable

        private void updateInfoForBootsFromLootTable(string selectedItem)
        {
            foreach (Item item in nmy.DropTable)
            {
                if (item is Boots boots)
                {
                    if (boots.ItemName == selectedItem)
                    {
                        tbItemDescription.Clear();
                        tbItemDescription.Text += boots.ItemName + Environment.NewLine + Environment.NewLine;
                        tbItemDescription.Text += boots.ItemDescription + Environment.NewLine;
                        tbItemDescription.Text += "Armor - " + boots.Armor + Environment.NewLine;
                        tbItemDescription.Text += "Durability - " + boots.Durability + Environment.NewLine;
                        tbItemDescription.Text += "Required Level - " + boots.RequiredLevel + Environment.NewLine;
                        tbItemDescription.ScrollToEnd();
                    }
                }
            }

        }
        #endregion

        #endregion

        #endregion

        #region potionSystem

        private void drinkHPPot()
        {
            string selectedPotion;
            try
            {
                selectedPotion = lbInventory.SelectedItem.ToString();

                if (selectedPotion.Contains("Potion"))
                {
                    try
                    {
                        foreach (Item item in _p1.Inventory)
                        {
                            if (item is HPPotion potion)
                            {
                                if (lbInventory.SelectedItem.ToString().Contains(selectedPotion))
                                {
                                    checkIfItIsReallyAPot(potion);

                                }
                            }
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("You have not selected a potion!");
                }

            }
            catch
            { MessageBox.Show("You have not selected an item!"); }
        }

        #region checkIfItIsReallyAPot

        private void checkIfItIsReallyAPot(HPPotion potion)
        {
            if (potion is HPPotion)
            {
                useHPPot(potion);
            }
            else
            { MessageBox.Show("This item is not a potion!"); }
        }
        #endregion

        #region useHPPot
        private void useHPPot(HPPotion potion)
        {
            int ammountRestored = rollAmmountRestored(potion.MinHealed, potion.MaxHealed);
            if (_p1.CurrHP < _p1.MaxHP && _p1.CurrHP > 0)
            {
                _p1.CurrHP = _p1.CurrHP + ammountRestored;
                
                if (_p1.CurrHP > _p1.MaxHP)
                {
                    _p1.CurrHP = _p1.MaxHP;
                }
                lblPlayerHP.Content = _p1.CurrHP;
                if (potion.Quantity > 1)
                {
                    potion.Quantity = potion.Quantity - 1;
                }
                else
                {
                    _p1.Inventory.RemoveAt(lbInventory.SelectedIndex);
                    tbItemDescription.Clear();
                }
                refreshInventory();
            }
            else
            {
                MessageBox.Show("You are already at max HP!");
            }
        }
        #endregion

        #region rollAmountRestored

        private int rollAmmountRestored(int min, int max)
        {
            Random rnd = new Random();
            int ammount = rnd.Next(min, max + 1);
            Thread.Sleep(1);
            return ammount;
        }
        #endregion

        #endregion

        #region randomNumber

        private int rndNumber(int min, int max)
        {
            Random rnd = new Random();
            int random = rnd.Next(min,max);
            return random;
        }
        #endregion

        #region timeStamp

        private string timeStamp()
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss tt");
            return timestamp;
        }
        #endregion

        #region delay

        async Task delay(int ms)
        {
            await Task.Delay(ms);
        }
        #endregion

        #region timer

        #region hpRegen
        private void initHpRegTimer()
        {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(hpRegen);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        public void  hpRegen(object sender, EventArgs e)
        {
            if (_p1.CurrHP < _p1.MaxHP && !combatState && _p1.CurrHP > 0)
            {
                _p1.CurrHP = _p1.CurrHP + _p1.HPregen;
                lblPlayerHP.Content = _p1.CurrHP;
            }
            
        }








        #endregion

        #endregion

        
    }
}
