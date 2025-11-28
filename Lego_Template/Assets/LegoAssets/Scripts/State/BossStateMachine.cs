public class BossStateMachine
    {
        public IBossState CurrentState { get; private set; }
        public void initialize(IBossState initailState)
        {
            CurrentState = initailState;
            CurrentState.Enter();
        }
        public void ChangeState(IBossState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        public void Tick()
        {
            CurrentState?.Tick();
        }
    }
