using System;
using System.Collections.Generic;

namespace Blockchain_test
{
    class BlockChain
    {
        public IList<Block> Chain { get; set; }

        public BlockChain()
        {
            InitializeChain();
            AddStartBlock();
        }

        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateStartBlock()
        {
            return new Block(DateTime.Now, null,"{}");
        }

        public void AddStartBlock()
        {
            Chain.Add(CreateStartBlock());
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
            if(!IsValid())
                throw new NotValidException("Chain is not correct");
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];
                if (currentBlock.Hash != currentBlock.CalculateHash())
                    return false;
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }

            return true;
        }
    }
}
