using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriTowers.DataModel
{

    public class GameDataSource
    {
        private const string GAME_FOLDER = "Static_GameItem";
        
        public GameItem GameStats { get; set; }

        public async void LoadCachedGameItem()
        {
            GameStats = new GameItem();
            try
            {
                foreach (var item in await StorageUtility.ListItems(GAME_FOLDER))
                {
                    GameStats = await StorageUtility.RestoreItem<GameItem>(GAME_FOLDER, item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

         #region Save
        public async Task SaveGameStats(GameItem gameItem)
        {
            try
            {
                await UpdateCacheGame(gameItem);
                SetupGameItem(gameItem);
            }
            catch (Exception) { throw; }
        }

        private void SetupGameItem(GameItem gameItem)
        {
            GameStats = new GameItem();
            GameStats = gameItem;

        }
        #endregion

        private async Task UpdateCacheGame(GameItem gameItem)
        {
            await StorageUtility.Clear(GAME_FOLDER);
            await StorageUtility.SaveItem(GAME_FOLDER, gameItem, gameItem.Id);
        }
    }
}
