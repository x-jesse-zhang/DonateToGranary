using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Overlay;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace DonateToGranary
{
    internal class DonateFoodBaseBehavior : CampaignBehaviorBase
    {

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.AddGranaryMenuItems));
        }

        private void AddGranaryMenuItems(CampaignGameStarter campaignGameStarter)
        {
            int playerGrain = 0;
            int freeSpaceInGranary = 0;

            campaignGameStarter.AddGameMenuOption("town_keep", "granary_keep", "{=granary_keep}Visit the granary", delegate (MenuCallbackArgs args)
            {
                bool canUseGranary;

                if (Hero.MainHero.CurrentSettlement.OwnerClan != Hero.MainHero.Clan)
                {
                    canUseGranary = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    args.Tooltip = new TextObject("You can add grain to the granary.", null);
                    args.IsEnabled = true;
                    canUseGranary = true;
                }

                return canUseGranary;
            }, delegate (MenuCallbackArgs args)
            {
                GameMenu.SwitchToMenu("granary_keep_menu");
            }, false, 1, false);

            campaignGameStarter.AddGameMenu("granary_keep_menu", "{=granary_keep_menu}You are at the granary.", delegate (MenuCallbackArgs args)
            {
                playerGrain = this.GetPlayerGrainAmount();
                freeSpaceInGranary = this.GetGranarySpace();
            }, GameOverlays.MenuOverlayType.SettlementWithBoth, GameMenu.MenuFlags.None, null);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_report", "{=granary_keep_report}View the granary report.", delegate (MenuCallbackArgs args)
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                return true;
            }, delegate (MenuCallbackArgs args)
            {
                this.ShowGranaryReport(playerGrain, freeSpaceInGranary);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_max", "{=granary_keep_add_max}Add the maximum amount of grain", delegate (MenuCallbackArgs args)
            {
                bool canAddGrain;

                if (freeSpaceInGranary == 0)
                {
                    canAddGrain = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    canAddGrain = true;
                }

                return canAddGrain;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(10000);
            }, false, -1, false);

            //this.AddTownMenuOptionForAddGrain(campaignGameStarter, 50, playerGrain, freeSpaceInGranary);
            //this.AddTownMenuOptionForAddGrain(campaignGameStarter, 100, playerGrain, freeSpaceInGranary);
            //this.AddTownMenuOptionForAddGrain(campaignGameStarter, 150, playerGrain, freeSpaceInGranary);
            //this.AddTownMenuOptionForAddGrain(campaignGameStarter, 200, playerGrain, freeSpaceInGranary);
            //this.AddTownMenuOptionForAddGrain(campaignGameStarter, 300, playerGrain, freeSpaceInGranary);

            
            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_50", "{=granary_keep_add_50}Add 50 units of grain", delegate (MenuCallbackArgs args)
            {
                bool canAddGrain;
                if (playerGrain < 50 || freeSpaceInGranary < 50)
                {
                    canAddGrain = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    canAddGrain = true;
                }
                return canAddGrain;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(50);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_100", "{=granary_keep_add_100}Add 100 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 100 || freeSpaceInGranary < 100;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(100);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_150", "{=granary_keep_add_150}Add 150 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 150 || freeSpaceInGranary < 150;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(150);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_200", "{=granary_keep_add_200}Add 200 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 200 || freeSpaceInGranary < 200;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(200);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_add_300", "{=granary_keep_add_300}Add 300 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 300 || freeSpaceInGranary < 300;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(300);
            }, false, -1, false);
            

            campaignGameStarter.AddGameMenuOption("granary_keep_menu", "granary_keep_decline", "{=granary_keep_decline}Leave", delegate (MenuCallbackArgs args)
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Leave;
                return true;
            }, delegate (MenuCallbackArgs args)
            {
                GameMenu.SwitchToMenu("town_keep");
            }, false, -1, false);

            // *** Castle ***
            campaignGameStarter.AddGameMenuOption("castle", "granary_castle", "{=granary_castle}Visit the granary", delegate (MenuCallbackArgs args)
            {
                bool canUseGranary;

                if (Hero.MainHero.CurrentSettlement.OwnerClan != Hero.MainHero.Clan)
                {
                    canUseGranary = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    args.Tooltip = new TextObject("You can add grain directly to the castle granary.", null);
                    args.IsEnabled = true;
                    canUseGranary = true;
                }

                return canUseGranary;
            }, delegate (MenuCallbackArgs args)
            {
                GameMenu.SwitchToMenu("granary_castle_menu");
            }, false, 1, false);

            campaignGameStarter.AddGameMenu("granary_castle_menu", "{=granary_castle_menu}You are at the granary.", delegate (MenuCallbackArgs args)
            {
                playerGrain = this.GetPlayerGrainAmount();
                freeSpaceInGranary = this.GetGranarySpace();
            }, GameOverlays.MenuOverlayType.SettlementWithBoth, GameMenu.MenuFlags.None, null);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_report", "{=granary_castle_report}View the granary report.", delegate (MenuCallbackArgs args)
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                return true;
            }, delegate (MenuCallbackArgs args)
            {
                this.ShowGranaryReport(playerGrain, freeSpaceInGranary);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_max", "{=granary_castle_add_max}Add the maximum amount of grain", delegate (MenuCallbackArgs args)
            {
                bool canAddGrain;

                if (freeSpaceInGranary == 0)
                {
                    canAddGrain = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    canAddGrain = true;
                }

                return canAddGrain;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(10000);
            }, false, -1, false);

            //this.AddCastleMenuOptionForAddGrain(campaignGameStarter, 50, playerGrain, freeSpaceInGranary);
            //this.AddCastleMenuOptionForAddGrain(campaignGameStarter, 100, playerGrain, freeSpaceInGranary);
            //this.AddCastleMenuOptionForAddGrain(campaignGameStarter, 150, playerGrain, freeSpaceInGranary);
            //this.AddCastleMenuOptionForAddGrain(campaignGameStarter, 200, playerGrain, freeSpaceInGranary);
            //this.AddCastleMenuOptionForAddGrain(campaignGameStarter, 300, playerGrain, freeSpaceInGranary);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_50", "{=granary_castle_add_50}Add 50 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 50 || freeSpaceInGranary < 50;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(50);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_100", "{=granary_castle_add_100}Add 100 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 100 || freeSpaceInGranary < 100;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(100);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_150", "{=granary_castle_add_150}Add 150 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 150 || freeSpaceInGranary < 150;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(150);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_200", "{=granary_castle_add_200}Add 200 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 200 || freeSpaceInGranary < 200;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(200);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_add_300", "{=granary_castle_add_300}Add 300 units of grain", delegate (MenuCallbackArgs args)
            {
                bool flag = playerGrain < 300 || freeSpaceInGranary < 300;
                bool result;
                if (flag)
                {
                    result = false;
                }
                else
                {
                    args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                    result = true;
                }
                return result;
            }, delegate (MenuCallbackArgs args)
            {
                this.AddGrain(300);
            }, false, -1, false);

            campaignGameStarter.AddGameMenuOption("granary_castle_menu", "granary_castle_decline", "{=granary_castle_decline}Leave", delegate (MenuCallbackArgs args)
            {
                args.optionLeaveType = GameMenuOption.LeaveType.Leave;
                return true;
            }, delegate (MenuCallbackArgs args)
            {
                bool isCastle = Hero.MainHero.CurrentSettlement.IsCastle;
                if (isCastle)
                {
                    GameMenu.SwitchToMenu("castle");
                }
                else
                {
                    GameMenu.SwitchToMenu("town_keep");
                }
            }, false, -1, false);
        }

        private void AddTownMenuOptionForAddGrain(CampaignGameStarter campaignGameStarter, int amountToAdd, int playerGrain, int granarySpace)
        {
            string amountAsString = amountToAdd.ToString();

            campaignGameStarter.AddGameMenuOption(
                "granary_keep_menu", 
                String.Format("granary_keep_add_{0}", amountAsString), 
                String.Format("{=granary_keep_add_{0}}Add {0} units of grain", amountAsString), 
                delegate (MenuCallbackArgs args)
                {
                    bool canAddGrain;
                    if (playerGrain < amountToAdd || granarySpace < amountToAdd)
                    {
                        canAddGrain = false;
                    }
                    else
                    {
                        args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                        canAddGrain = true;
                    }
                    return canAddGrain;
                }, 
                delegate (MenuCallbackArgs args)
                {
                    this.AddGrain(amountToAdd);
                }, false, -1, false
            );
        }

        private void AddCastleMenuOptionForAddGrain(CampaignGameStarter campaignGameStarter, int amountToAdd, int playerGrain, int granarySpace)
        {
            string amountAsString = amountToAdd.ToString();

            campaignGameStarter.AddGameMenuOption(
                "granary_castle_menu",
                String.Format("granary_castle_add_{0}", amountAsString),
                String.Format("{=granary_castle_add_{0}}Add {0} units of grain", amountAsString),
                delegate (MenuCallbackArgs args)
                {
                    bool canAddGrain;
                    if (playerGrain < amountToAdd || granarySpace < amountToAdd)
                    {
                        canAddGrain = false;
                    }
                    else
                    {
                        args.optionLeaveType = GameMenuOption.LeaveType.Submenu;
                        canAddGrain = true;
                    }
                    return canAddGrain;
                },
                delegate (MenuCallbackArgs args)
                {
                    this.AddGrain(amountToAdd);
                }, false, -1, false
            );
        }

        private void AddGrain(int amount)
        {
            int playerGrain = this.GetPlayerGrainAmount();
            int freeSpaceInGranary = this.GetGranarySpace();
            int maxTransaction;

            if (playerGrain > freeSpaceInGranary)
            {
                maxTransaction = freeSpaceInGranary;
            }
            else
            {
                maxTransaction = playerGrain;
            }

            int transferAmount = amount;

            if (transferAmount > maxTransaction)
            {
                transferAmount = maxTransaction;
            }

            float foodAmount = Settlement.CurrentSettlement.Town.FoodStocks;
            foodAmount += (float)transferAmount;

            float granaryMaxAmount = (float)Settlement.CurrentSettlement.Town.FoodStocksUpperLimit();

            if (foodAmount > granaryMaxAmount)
            {
                foodAmount = (float)Settlement.CurrentSettlement.Town.FoodStocksUpperLimit();
            }

            Settlement.CurrentSettlement.Town.FoodStocks = foodAmount;
            int reportAmount = transferAmount;

            transferAmount *= -1;
            PartyBase.MainParty.ItemRoster.AddToCounts(MBObjectManager.Instance.GetObject<ItemObject>("grain"), transferAmount);

            string title = "Grain Transferred";
            string message = reportAmount.ToString() + " units of grain have been transferred to " + Settlement.CurrentSettlement.GetName().ToString() + "'s granary.\n";

            if (Settlement.CurrentSettlement.IsTown)
            {
                message += "The local notables were impressed with your generosity.";
            }

            InformationManager.ShowInquiry(new InquiryData(title, message, true, false, "OK", "", null, null, ""), true);
            this.GetCreditForHelping(reportAmount);

            bool isCastle = Settlement.CurrentSettlement.IsCastle;
            if (isCastle)
            {
                GameMenu.SwitchToMenu("castle");
            }
            else
            {
                GameMenu.SwitchToMenu("town_keep");
            }
        }

        private int GetPlayerGrainAmount()
        {
            return PartyBase.MainParty.ItemRoster.GetItemNumber(MBObjectManager.Instance.GetObject<ItemObject>("grain"));
        }

        private int GetGranarySpace()
        {
            int foodMax = Settlement.CurrentSettlement.Town.FoodStocksUpperLimit();
            float currentFoodAmount = Settlement.CurrentSettlement.Town.FoodStocks;
            return foodMax - (int)currentFoodAmount;
        }

        private void ShowGranaryReport(int playerGrain, int freeSpaceInGranary)
        {
            string title = "Granary Report";
            string message = "You have " + playerGrain.ToString() + " grain in your inventory.\n";
            bool isCastle = Settlement.CurrentSettlement.IsCastle;
            message = message + Settlement.CurrentSettlement.GetName().ToString() + " has " + freeSpaceInGranary.ToString() + " space in its granary.";
            //if (isCastle)
            //{
            //    message = message + "The castle has " + freeSpaceInGranary.ToString() + " space in it's granary.";
            //}
            //else
            //{
            //    message = message + "The town has " + freeSpaceInGranary.ToString() + " space in it's granary.";
            //}
            InformationManager.ShowInquiry(new InquiryData(title, message, true, false, "OK", "", null, null, ""), true);
        }

        private void GetCreditForHelping(int amount)
        {
            int relation = amount / 50;
            foreach (Hero hero in Settlement.CurrentSettlement.Notables)
            {
                this.JustAddRelation(Hero.MainHero, hero, relation);
            }
        }

        private void JustAddRelation(Hero hero1, Hero hero2, int relationChange)
        {
            int finalRelation = CharacterRelationManager.GetHeroRelation(hero1, hero2) + relationChange;
            finalRelation = MBMath.ClampInt(finalRelation, -100, 100);
            hero1.SetPersonalRelation(hero2, finalRelation);
        }

        private void RemoveGrain()
        {
            Settlement.CurrentSettlement.Town.FoodStocks = 0f;
        }

        private bool DoesItemExist(Town town, string itemID)
        {
            return town.Owner.ItemRoster.FindIndexOfItem(MBObjectManager.Instance.GetObject<ItemObject>(itemID)) != -1;
        }

        public override void SyncData(IDataStore dataStore) {}
    }
}
