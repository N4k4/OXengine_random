using System;
using System.Threading;
using System.Threading.Tasks;

namespace OXengine_random.EventHandler
{
    //イベント処理用デリゲート
    delegate void StdinEventHandler(string[] stringArg);


    /// <summary>
    /// 標準入力イベント待ち受け
    /// </summary>
    class StdinEventLoop
    {
        //入力時に呼ばれるイベント
        public event StdinEventHandler OnMessage;

        public StdinEventLoop(){}

        public StdinEventLoop(StdinEventHandler onMessage){
            OnMessage += onMessage;
        }

        public Task Start(CancellationToken ct)
        {
            return Task.Run(() => EventLoop(ct));
        }

        void EventLoop(CancellationToken ct)
        {
            //イベントループ
            while(!ct.IsCancellationRequested)
            {
                
            }
        }

    }
}
