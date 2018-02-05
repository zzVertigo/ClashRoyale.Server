using System.Collections.Generic;
using System.Linq;
using ClashRoyale.Server.Logic.Slots.Items;
using Newtonsoft.Json;

namespace ClashRoyale.Server.Logic.Slots
{
    internal class Resources : Dictionary<int, Resource>
    {
        [JsonProperty("player")] internal Player Player;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        internal Resources()
        {
            // Resources.
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resources" /> class.
        /// </summary>
        /// <param name="Player">The player.</param>
        internal Resources(Player Player, bool Init = false)
        {
            this.Player = Player;

            if (Init) Initialize();
        }

        /// <summary>
        ///     Gets the normal resources.
        /// </summary>
        internal Resource[] Normals
        {
            get { return Values.Where(Pair => Pair.Data < 5000009).ToArray(); }
        }

        /// <summary>
        ///     Gets the special resources.
        /// </summary>
        internal Resource[] Specials
        {
            get { return Values.Where(Pair => Pair.Data > 5000008).ToArray(); }
        }

        /// <summary>
        ///     Sets the specified resource value.
        /// </summary>
        /// <param name="Resource">The resource.</param>
        /// <param name="Value">The value.</param>
        internal void Set(int Resource, int Value)
        {
            if (ContainsKey(Resource))
                this[Resource].Count = Value;
            else
                Add(Resource, new Resource(Resource, Value));
        }

        /// <summary>
        ///     Sets the specified resource value.
        /// </summary>
        /// <param name="Resource">The resource.</param>
        internal void Set(Resource Resource)
        {
            if (ContainsKey(Resource.Data))
                this[Resource.Data].Count = Resource.Count;
            else
                Add(Resource.Data, Resource);
        }

        /// <summary>
        ///     Sets the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        /// <param name="Value">The value.</param>
        internal void Set(Enums.Resource Data, int Value)
        {
            Set(5000000 + (int) Data, Value);
        }

        /// <summary>
        ///     Gets the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        internal int Get(Enums.Resource Data)
        {
            return Get(5000000 + (int) Data);
        }

        /// <summary>
        ///     Gets the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        internal int Get(int Data)
        {
            return ContainsKey(Data) ? this[Data].Count : 0;
        }

        /// <summary>
        ///     Minuses the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        /// <param name="Value">The value.</param>
        internal void Minus(Enums.Resource Data, int Value)
        {
            if (ContainsKey(5000000 + (int) Data)) this[5000000 + (int) Data].Count -= Value;
        }

        /// <summary>
        ///     Minuses the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        /// <param name="Value">The value.</param>
        internal void Minus(int Data, int Value)
        {
            if (ContainsKey(Data)) this[Data].Count -= Value;
        }

        /// <summary>
        ///     Pluses the specified resource value.
        /// </summary>
        /// <param name="Data">The resource.</param>
        /// <param name="Value">The value.</param>
        internal void Plus(Enums.Resource Data, int Value)
        {
            //int Cap = (CSV.Tables.Get(Enums.Gamefile.Resources).GetDataWithID(5000000 + (int)Data) as Files.CSV_Logic.Resources).Cap;

            //if (this.ContainsKey(5000000 + (int)Data))
            //{
            //    if (Cap > 0 && this[5000000 + (int)Data].Count + Value > 0)
            //    {
            //        this[5000000 + (int)Data].Count = Cap;
            //    }
            //    else
            //    {
            //        this[5000000 + (int)Data].Count += Value;
            //    }
            //}
            //else
            //{
            //    this.Set(Data, Value > Cap ? Cap : Value);
            //}
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        internal void Initialize()
        {
            Set(Enums.Resource.GEMS, 999999);
            Set(Enums.Resource.GOLD, 999999);
            Set(Enums.Resource.CHEST_INDEX, 6);
            Set(Enums.Resource.CHEST_COUNT, 0);
            Set(Enums.Resource.STAR_COUNT, 0);
            Set(Enums.Resource.FREE_GOLD, 0);
            Set(Enums.Resource.MAX_TROPHIES, 0);
            Set(Enums.Resource.THREE_CROWN_WINS, 0);
            Set(Enums.Resource.CARD_COUNT, 0);
            Set(Enums.Resource.FAVOURITE_SPELL, 0);
            Set(Enums.Resource.DONATIONS, 0);
            Set(Enums.Resource.REWARD_GOLD, 0);
            Set(Enums.Resource.REWARD_COUNT, 0);
            Set(Enums.Resource.SHOP_DAY_COUNT, 0);
            Set(Enums.Resource.SPECIAL_OFFER_LEGEND_INDEX, 0);
            Set(Enums.Resource.SPECIAL_OFFER_EPIC_INDEX, 0);
            Set(Enums.Resource.SPECIAL_OFFER_STARTER_PACK_INDEX, 0);
            Set(Enums.Resource.SURVIVAL_MAX_WINS, 0);
            Set(Enums.Resource.SURVIVAL_CARDS_WON, 0);
            Set(Enums.Resource.EPIC_CHEST_INDEX, 0);
            Set(Enums.Resource.REFUND_ACHIEVEMENT_CREATE_GR, 0);
            Set(Enums.Resource.PRODUCT_RED_PURCHASE_COUNT, 0);
            Set(Enums.Resource.BLIND_DECK_SEED, 0);
            Set(Enums.Resource.BLIND_DECK_INDEX, 0);
            Set(Enums.Resource.MAX_ARENA, Player.Arena);
        }

        /// <summary>
        ///     Updates this instance.
        /// </summary>
        internal void Update()
        {
            if (Get(Enums.Resource.REWARD_GOLD) > 0) Set(Enums.Resource.REWARD_GOLD, 0);

            if (Player.Trophies > Get(Enums.Resource.MAX_TROPHIES)) Set(Enums.Resource.MAX_TROPHIES, Player.Trophies);

            if (Player.Arena > Get(Enums.Resource.MAX_ARENA)) Set(Enums.Resource.MAX_ARENA, Player.Arena);

            Set(Enums.Resource.CARD_COUNT, 0);
        }
    }
}