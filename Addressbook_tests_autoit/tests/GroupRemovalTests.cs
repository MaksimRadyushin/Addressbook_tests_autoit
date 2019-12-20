﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
    {
        public Random rnd = new Random();

        [Test]
        public void RemoveGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();//Получем список имеющихся групп
            GroupData newGroup = null;//Создаём и инициализируем контейнер для хранения группы
            if (oldGroups.Count < 2)// Проверяем содержиме списка групп, если списиок содержит 1 группу или совсем не содержит групп
            {
                for (int i = 0; i < 3; i++)//То мы добавляем ещё например 3 (Так как в приложении запрещено удалять последнююгруппу)
                {
                    newGroup = new GroupData()
                    {
                        Name = "Test" + i
                    };
                    app.Groups.Add(newGroup);
                }
            }
           
            oldGroups = app.Groups.GetGroupList();//Получем список имеющихся групп
            app.Groups.RemoveGroup(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }    
}