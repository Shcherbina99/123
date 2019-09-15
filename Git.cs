using System;
using System.Collections.Generic;
using System.Linq;

namespace GitTask
{
    public class Git
    {
        public readonly int FilesCount;
        public List<Commit> Commits = new List<Commit>();
        Commit Hash;


        public Git(int filesCount)
        {
            FilesCount = filesCount;
            Hash = new Commit(0);
        }

        public void Update(int fileNumber, int value)
        {
            if (Check(fileNumber))
                Hash.Change(fileNumber, value);
            else
            {
                throw new ArgumentException();
            }
        }

        public int Commit()
        {
            Commits.Add(Hash);
            Hash = new Commit(Hash.CommitCount + 1);
            return Hash.CommitCount - 2;
        }

        public int Checkout(int commitNumber, int fileNumber)
        {

            if (Check(fileNumber) && commitNumber >= 0 && commitNumber < Hash.CommitCount)
            {
                for (int i = commitNumber; i >= 0; i--)
                {
                    if (Commits[i].Hash.ContainsKey(fileNumber))
                    {
                        return Commits[i].Hash[fileNumber];
                    }
                }

                return 0;
            }

            throw new ArgumentException();
        }

        private bool Check(int number)
        {
            return number >= 0 && number < FilesCount;
        }
    }

    public class Commit
    {
        public Dictionary<int, int> Hash = new Dictionary<int, int>();
        public int CommitCount;


        public Commit(int commitCount)
        {
            CommitCount = commitCount;
        }

        public void Change(int fileCount, int value)
        {
            Hash[fileCount] = value;
        }
    }
}