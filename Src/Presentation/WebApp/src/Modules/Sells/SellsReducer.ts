import { ReducersType } from './Redux/Helpers';
import { ISellsState, SellsReducer } from './Redux/Reducer';

type SellsReducers = ISellsState;

export default  {
  sells: SellsReducer
} as ReducersType<SellsReducers>