import { Action } from 'redux';
import { ActionsUnion } from './Helpers';

export const LOADSELLS = 'SELLS/LOAD';
export const SETSELLS = 'SELLS/SET';

export interface ILoadSells extends Action { type: typeof LOADSELLS; }
export interface ISetSells extends Action { type: typeof SETSELLS; payload: any; }

export const SellActions = {
  loadSells: () => ({ type: LOADSELLS}) as ILoadSells,
  setSells: (payload: any) => ({ type: SETSELLS, payload }) as ISetSells
};

export type TCoreUIActions = ActionsUnion<typeof SellActions>;