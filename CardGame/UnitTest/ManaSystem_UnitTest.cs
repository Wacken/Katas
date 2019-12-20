#define GUIDING

using NUnit.Framework;


namespace CardGame.UnitTest
{

    [TestFixture]
    public class ManaSystem_UnitTest
    {
        private ManaPoolBase _emptyManaPoolBase;

        [SetUp]
        public void Setup()
        {
            _emptyManaPoolBase = createPool(0);
        }

#if GUIDING
        [Test]
        public void Using5ManaAnd3Mana_6PoolExtend_ThrowNotEnoughMana()
        {
            ManaPoolBase manaPoolBase = createPool(6);
            manaPoolBase.extend();
            
            manaPoolBase.use(5);
            
            Assert.Throws<ManaPoolBase.NotEnoughMana>(() => manaPoolBase.use(3));
        }
#endif

        [Test]
        public void Size_EmptyPool_0()
        {
            testCapacityAndSize(0,0,_emptyManaPoolBase);
        }

        [Test]
        public void Extend_EmptyPool_Size1()
        {
            _emptyManaPoolBase.extend();

            testCapacityAndSize(1,1,_emptyManaPoolBase);
        }

        [Test]
        public void Extend_1Pool_Size2()
        {
            ManaPoolBase manaPoolBase = createPool(1);
            
            manaPoolBase.extend();

            testCapacityAndSize(2,2,manaPoolBase);
        }

        [Test]
        public void Use1_1Pool_Size0()
        {
            ManaPoolBase manaPoolBase = createPool(1);
            
            manaPoolBase.use(1);
            
            Assert.AreEqual(0,manaPoolBase.Content);
        }
        
        [Test]
        public void Use1_2Pool_Size1()
        {
            ManaPoolBase manaPoolBase = createPool(2);
            
            manaPoolBase.use(1);
            
            Assert.AreEqual(1,manaPoolBase.Content);
        }

        [Test]
        public void Use1_EmptyPool_ThrowNotEnoughMana()
        {
            Assert.Throws<ManaPoolBase.NotEnoughMana>(() => _emptyManaPoolBase.use(1));
        }

        [Test]
        public void Use0_EmptyPool_Size0()
        {
            _emptyManaPoolBase.use(0);
            
            testCapacityAndSize(0,0,_emptyManaPoolBase);
        }

        [Test]
        public void Use2_5Pool_Capacity5()
        {
            ManaPoolBase manaPoolBase = createPool(5);
            
            manaPoolBase.use(2);
            
            testCapacityAndSize(3,5,manaPoolBase);
        }

        [Test]
        public void Refill_5Pool2Content_Content5()
        {
            ManaPoolBase manaPoolBase = createPool(5);
            manaPoolBase.use(3);

            manaPoolBase.refill();
            
            Assert.AreEqual(5,manaPoolBase.Content);
        }

        [Test]
        public void Refill_5FullPool_Content5()
        {
            ManaPoolBase manaPoolBase = createPool(5);
            
            manaPoolBase.refill();
            
            Assert.AreEqual(5,manaPoolBase.Content);
        }

        [Test]
        public void Extend_10Pool_Capacity10()
        {
            ManaPoolBase manaPoolBase = createPool(10);
            
            manaPoolBase.extend();
            
            Assert.AreEqual(10,manaPoolBase.Capacity);
        }

        public void testCapacityAndSize(int exptectedContent, int expectedCapacity, ManaPoolBase manaPoolBase)
        {
            Assert.AreEqual(exptectedContent,manaPoolBase.Content);
            Assert.AreEqual(expectedCapacity,manaPoolBase.Capacity);
        }

        public ManaPoolBase createPool(int capacity)
        {
            ManaPoolBase manaPoolBase = new ManaPoolBase();
            for (int j = 0; j < capacity; j++)
            {
                manaPoolBase.extend();
            }

            return manaPoolBase;
        }
    }


}