﻿using Jurassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserAPITest
{
    /// <summary>
    /// ScreenAPI 测试类
    /// </summary>
    [TestClass]
    public class ScreenAPITest
    {
        /// <summary>
        /// 场景：MessageChannelAPI在js引擎中使用
        /// 预期：不可使用
        /// </summary>
        [TestMethod]
        public void CannotUseInJSEnginee()
        {
            string jsFormat = "var f = function() {var i = 30; #replace# var j = 10; return i + j;}; f();";
            var engine = new ScriptEngine();
            IBrowserAPI api = new ScreenAPI();
            var result = engine.Evaluate<int>(jsFormat.Replace("#replace#", api.GetAPIJSCode()));

            Assert.AreNotEqual(result, 40);
        }

        /// <summary>
        /// 场景：测试浏览器可用性
        /// 预期：见被测试类注释
        /// </summary>
        [TestMethod]
        public void BrowserEnable()
        {
            IBrowserAPI api = new ScreenAPI();
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE6()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE7()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE8()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE9()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE10()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE11()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Chrome()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Firefox()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Opera()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Safari()));
        }
    }
}
