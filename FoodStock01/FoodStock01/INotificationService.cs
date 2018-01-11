namespace FoodStock01
{
    public interface INotificationService
    {
        //iOS用の登録
        void Regist();

        //通知する
        void On(string title, string subTitle, string body);

        //通知を解除する
        void Off();

        //0にする
        void return0();
    }
}
