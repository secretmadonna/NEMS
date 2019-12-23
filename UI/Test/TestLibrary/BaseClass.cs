using log4net;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SecretMadonna.NEMS.UI.TestLibrary
{
    /// <summary>
    /// 类修饰符（默认可访问性最低 internal）
    ///   一、可访问性：
    ///     1、public : 共有的，本程序集及其他程序集中的类均能访问。
    ///     2、internal : 内部的，同一程序集中可以访问。
    ///   二、abstract : 抽象类只能被继承。不能创建抽象类的实例。含抽象方法的类一定是抽象类。抽象类不能是密封的或静态的。
    ///   三、sealed : 密封类不能被继承。类不能既是静态的又是密封的。
    ///   四、static : 静态类不能含有对象成员，不能实例化。类不能既是静态的又是密封的。
    ///   五、partial : 部分类。可以将一个类分成几部分写在不同文件中，最终编译时将合并成一个文件，且各个部分不能分散在不同程序集中。
    /// </summary>
    public class BaseClass
    {
        #region 嵌套类
        /// <summary>
        /// 嵌套类修饰符（默认可访问性最低 private）
        ///   一、可访问性：
        ///     1、public : 共有的，本程序集及其他程序集中的类均能访问。
        ///     2、internal : 内部的，同一程序集中可以访问。
        ///     3、protected : 受保护的。继承的子类中可以访问，可以跨程序集。
        ///     4、protected internal 或 internal protected : 内部受保护的。同一程序集中，继承的子类中可以访问。
        ///     5、private : 私有的。本类可以访问。
        ///   二、abstract : 抽象类不能创建抽象类的实例。含抽象方法的类一定是抽象类。抽象类不能是密封的或静态的。
        ///   三、sealed : 密封类不能被继承。类不能既是静态的又是密封的。
        ///   四、static : 静态类不能含有对象成员，不能实例化。类不能既是静态的又是密封的。
        ///   五、partial : 部分类。可以将一个类分成几部分写在不同文件中，最终编译时将合并成一个文件，且各个部分不能分散在不同程序集中。
        /// </summary>
        class NestBaseClass
        {
        }
        class NestDerivedClass : NestBaseClass
        {
        }
        abstract class NestAbstractClass
        {
        }
        sealed class NestSealedClass
        {
        }
        static class NestStaticClass
        {
        }
        #endregion

        #region 类成员

        #region 数据成员（常量、字段、事件）
        #region 字段
        /// <summary>
        /// 字段修饰符（默认可访问性最低 private）
        ///   一、可访问性：
        ///     1、public : 共有的，本程序集及其他程序集中的类均能访问。
        ///     2、internal : 内部的，同一程序集中可以访问。
        ///     3、protected : 受保护的。继承的子类中可以访问，可以跨程序集。
        ///     4、protected internal 或 internal protected : 内部受保护的。同一程序集中，继承的子类中可以访问。
        ///     5、private : 私有的。本类可以访问。
        ///   二、readonly : 运行时只读，内容在运行时确定
        ///   三、const : 编译时只读，内容在编译时确定
        /// </summary>
        int Field;

        static readonly ILog logger = LogManager.GetLogger(typeof(BaseClass));
        static int numberIndex = 0;
        #endregion
        #endregion

        #region 函数成员（静态构造函数、构造函数、（属性、方法、运算符、索引器）、析构函数）
        #region 静态构造函数、构造函数、析构函数
        /// <summary>
        /// 静态构造函数
        ///   1、一个类中只能有一个静态构造函数，没有修饰符，没有参数
        ///   2、在“类被实例化”或“静态成员被调用”的时候先进行调用
        ///   3、静态构造函数只会被执行一次
        ///   4、静态构造函数中不能实例化实例成员
        /// </summary>
        static BaseClass()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseClass()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~BaseClass()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 字段修饰符（默认可访问性最低 private）
        ///   一、可访问性：
        ///     1、public : 共有的，本程序集及其他程序集中的类均能访问。
        ///     2、internal : 内部的，同一程序集中可以访问。
        ///     3、protected : 受保护的。继承的子类中可以访问，可以跨程序集。
        ///     4、protected internal 或 internal protected : 内部受保护的。同一程序集中，继承的子类中可以访问。
        ///     5、private : 私有的。本类可以访问。
        ///   二、virtual : 运行时只读，内容在运行时确定
        ///   三、override : 编译时只读，内容在编译时确定
        /// </summary>
        public int Property
        {
            get { return this.Field; }
            set
            {
                if (value > 0)
                {
                    this.Field = value;
                }
                else
                {
                    this.Field = 0;
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 字段修饰符（默认可访问性最低 private）
        ///   一、可访问性：
        ///     1、public : 共有的，本程序集及其他程序集中的类均能访问。
        ///     2、internal : 内部的，同一程序集中可以访问。
        ///     3、protected : 受保护的。继承的子类中可以访问，可以跨程序集。
        ///     4、protected internal 或 internal protected : 内部受保护的。同一程序集中，继承的子类中可以访问。
        ///     5、private : 私有的。本类可以访问。
        ///   二、readonly : 运行时只读，内容在运行时确定
        ///   三、const : 编译时只读，内容在编译时确定
        /// </summary>
        void Method()
        { }
        #endregion

        #region 运算符

        #endregion

        #region 索引器

        #endregion
        #endregion

        #endregion

        #region ExitProcess
        /// <summary>
        /// ExitProcess
        /// </summary>
        /// <param name="uExitCode"></param>
        [DllImport("kernel32.dll")]
        extern static void ExitProcess(uint uExitCode);
        #endregion





    }
}
