type FunctionType = (...args: any[]) => any;
interface IActionCreatorsMapObject { [actionCreator: string]: FunctionType };

export type ActionsUnion<A extends IActionCreatorsMapObject> = ReturnType<A[keyof A]>;

export type ReducersType<TReducers> = {
  [K in keyof TReducers]: () => TReducers[K];
};