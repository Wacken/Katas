using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace CardGame.UnitTest
{
    [TestFixture]
    public class Player_UnitTest
    {
        public class Draw : Player_UnitTest
        {
            [Test]
            public void draw_1CardDeck_deckIsEmpty()
            {
                var player = createPlayer();
                createFakeDeckIncreasing(player, 1);

                player.draw();

                Assert.IsEmpty(player.deck);
            }

            [Test]
            public void draw_1DeckCard0_handHasCard0()
            {
                var player = createPlayer();
                var attackCard = addCardToDeck(player, 0);

                player.draw();

                Assert.Contains(attackCard, player.hand);
            }

            [Test]
            public void draw_2Deck_handHasOneWhichDeckHasNot()
            {
                RandomGenerator stubGenerator = Substitute.For<RandomGenerator>();
                var player = createPlayer(stubGenerator);
                stubGenerator.Generate(Arg.Any<int>()).Returns(1);
                var attackCard0 = addCardToDeck(player, 0);
                var attackCard1 = addCardToDeck(player, 1);

                player.draw();
                
                CollectionAssert.DoesNotContain(player.deck,attackCard1);
                Assert.Contains(attackCard1,player.hand);
            }

            [Test]
            public void draw_5Deck_handHasThe4Card()
            {
                RandomGenerator stubGenerator = Substitute.For<RandomGenerator>();
                var player = createPlayer(stubGenerator);
                var attackCard0 = addCardToDeck(player, 0);
                var attackCard1 = addCardToDeck(player, 1);
                var attackCard2 = addCardToDeck(player, 2);
                var attackCard3 = addCardToDeck(player, 3);
                var attackCard4 = addCardToDeck(player, 4);
                stubGenerator.Generate(Arg.Any<int>()).Returns(3);
                
                player.draw();
                
                CollectionAssert.DoesNotContain(player.deck,attackCard3);
                Assert.Contains(attackCard3,player.hand);
            }

            [Test]
            public void draw_3CardDeck_CallsGenerator()
            {
                RandomGenerator mockGenerator = Substitute.For<RandomGenerator>();
                BasePlayer player = createPlayer(mockGenerator);
                var randomMax = 3;
                createFakeDeckIncreasing(player,randomMax);
                
                player.draw();

                mockGenerator.Received().Generate(randomMax);
            }

            [Test]
            public void draw_2CardDeck_1CardDeck()
            {
                var player = createPlayer();
                createFakeDeckIncreasing(player, 2);

                player.draw();

                Assert.AreEqual(1, player.deck.Count);
            }


            [Test]
            public void draw_EmptyDeck_deckIsEmpty()
            {
                var player = createPlayer();
                createFakeDeckIncreasing(player, 0);

                player.draw();

                Assert.AreEqual(0, player.deck.Count);
            }

            [Test]
            public void draw_EmptyHand1Deck_handNotEmpty()
            {
                var player = createPlayer();
                createFakeDeckIncreasing(player, 1);

                player.draw();

                Assert.IsNotEmpty(player.hand);
            }

            [Test]
            public void draw_HandHas2Card_HandHas3Card()
            {
                var player = createPlayer();
                createFakeDeckIncreasing(player,3);
                player.hand.Add(createAttackCard());
                player.hand.Add(createAttackCard());
                
                player.draw();
                
                Assert.AreEqual(3,player.hand.Count);
            }
        }

        public class Prepare : Player_UnitTest
        {
            [Test]
            public void GivenManaPool_ExtendWasCalled()
            {
                ManaPool mockPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayer(mockPool);
                

                player.refresh();
                
                mockPool.Received().extend();
            }

            [Test]
            public void GivenManaPool_RefillWasCalled()
            {
                ManaPool mockPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayer(mockPool);
                
                player.refresh();
                
                mockPool.Received().refill();
            }

            [Test]
            public void GivenManaPool_RefillAfterExtendCalled()
            {
                ManaPool mockPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayer(mockPool);
                
                player.refresh();
                
                Received.InOrder(()=>{mockPool.extend(); mockPool.refill();});
            }
        }

        public class PlayCard : Player_UnitTest
        {
            [Test]
            public void Given1Card_HandIsEmpty()
            {
                BasePlayer player = createPlayerWithEnemy();
                var card = createAttackCard();
                player.hand.Add(card);

                player.playCard(card);
                
                Assert.AreEqual(0,player.hand.Count);
            }

            [Test]
            public void Given2Card_Hand1Card()
            {
                BasePlayer player = createPlayerWithEnemy();
                var stubCard = createAttackCard();
                player.hand.Add(stubCard);
                player.hand.Add(createAttackCard());
                
                player.playCard(stubCard);
                
                Assert.AreEqual(1,player.hand.Count);
            }

            [Test]
            public void Given2Card_HandNotContainPlayed()
            {
                ManaPool stubPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayerWithEnemy(stubPool);
                player.hand.Add(createAttackCard());
                var stubCard = createAttackCard(1);
                player.hand.Add(stubCard);
                
                player.playCard(stubCard);
                
                CollectionAssert.DoesNotContain(player.hand,stubCard);
            }

            [Test]
            public void Given1Card0_Use0ManaWasCalled()
            {
                ManaPool mockPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayerWithEnemy(mockPool);
                var stubCard = createAttackCard(0);
                player.hand.Add(stubCard);
                
                player.playCard(stubCard);
                
                mockPool.Received().use(0);
            }
            
            [Test]
            public void Given1Card1_Use1ManaWasCalled()
            {
                ManaPool mockPool = Substitute.For<ManaPool>();
                BasePlayer player = createPlayerWithEnemy(mockPool);
                var stubCard = createAttackCard(1);
                player.hand.Add(stubCard);
                
                player.playCard(stubCard);
                
                mockPool.Received().use(1);
            }

            [Test]
            public void GivenCard0_EnemyReceived0Damage()
            {
                Player mockEnemy = Substitute.For<Player>();
                Game stubGame = Substitute.For<Game>();
                stubGame.getOpponent().Returns(mockEnemy);
                BasePlayer player = createPlayer(stubGame);
                var stubCard = createAttackCard(0);
                player.hand.Add(stubCard);
                
                player.playCard(stubCard);

                mockEnemy.Received().takeDamage(0);
            }

            [Test]
            public void GivenCard1_EnemyReceived1Damage()
            {
                Player mockEnemy = Substitute.For<Player>();
                Game stubGame = Substitute.For<Game>();
                stubGame.getOpponent().Returns(mockEnemy);
                ManaPool pool = Substitute.For<ManaPool>();
                pool.use(Arg.Any<int>());
                BasePlayer player = createPlayer(pool,stubGame);
                var stubCard = createAttackCard(1);
                player.hand.Add(stubCard);
                
                player.playCard(stubCard);

                mockEnemy.Received().takeDamage(1);
            }
        }

        public class TakeDamage : Player_UnitTest
        {
            [Test]
            public void GivenFullLife0Damage_ReturnFullLife()
            {
                Player player = createPlayer();
                
                player.takeDamage(0);
                
                Assert.AreEqual(30,player.getLife());
            }

            [Test]
            public void GivenFullLife1Damage_Return29Life()
            {
                Player player = createPlayer();
                
                player.takeDamage(1);
                
                Assert.AreEqual(29,player.getLife());
            }
        }
        
        protected static BasePlayer createPlayer()
        {
            return new BasePlayer(null,null,null);
        }

        protected static void createFakeDeckIncreasing(BasePlayer player, int deckSize)
        {
            for (var i = 0; i < deckSize; i++)
                addCardToDeck(player, i);
        }

        protected static Card addCardToDeck(BasePlayer player, int manaCost)
        {
            var attackCard = createAttackCard(manaCost);
            player.deck.Add(attackCard);
            return attackCard;
        }

        protected static Card createAttackCard(int manaCost = 0)
        {
            var attackCard = Substitute.For<Card>();
            attackCard.ManaCost.Returns(manaCost);
            return attackCard;
        }

        private BasePlayer createPlayer(ManaPool pool)
        {
            return new BasePlayer(null,pool,null);
        }

        private BasePlayer createPlayer(RandomGenerator generator)
        {
            return new BasePlayer(generator,null,null);
        }

        protected BasePlayer createPlayer(Game game)
        {
            return new BasePlayer(null,null,game);
        }

        protected BasePlayer createPlayer(ManaPool pool, Game game)
        {
            return new BasePlayer(null,pool,game);
        }

        protected BasePlayer createPlayerWithEnemy()
        {
            return createPlayerWithEnemy(null);
        }

        protected BasePlayer createPlayerWithEnemy(ManaPool pool)
        {
            Game stubGame = Substitute.For<Game>();
            Player stubEnemy = Substitute.For<Player>();
            stubGame.getOpponent().Returns(stubEnemy);   
            return new BasePlayer(null,pool,stubGame);
        }
    }
}