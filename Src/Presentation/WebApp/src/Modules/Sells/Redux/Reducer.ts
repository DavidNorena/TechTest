import { Reducer } from 'redux';
import * as A from './Actions';

export interface ISellsState {
  sells: ISellsStore;
}

export interface ISellsStore {
  loading: boolean;
  sells: [];
}

const INITIAL_STATE: ISellsStore = {
  loading: false,
  sells: []
};

export const SellsReducer: Reducer<ISellsStore, A.TCoreUIActions> =
  (state: ISellsStore = INITIAL_STATE, action: A.TCoreUIActions): ISellsStore => {
    switch (action.type) {
      case A.LOADSELLS:
        return { ...state, loading: true, sells: [] };
      case A.SETSELLS:
      return { ...state, loading: true, sells: action.payload };
      default:
        return state;
    }
  };