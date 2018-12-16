using System;

namespace Singleton
{
    public class SingletonA <T> where T: class
    {
        private static T singletonInstance;
        private static readonly object locker = new object();

        protected SingletonA() { }

        public static T Instance
        {
            get
            {
                if (singletonInstance == null)
                {
                    lock (locker)
                    {
                        if (singletonInstance == null)
                        {
                            singletonInstance = (T)Activator.CreateInstance(typeof(T), true); // create instance of type on inheritance path
                                                                                              // is not pulic 
                        }
                    }
                }

                return singletonInstance;
            }
        }

    }
}
