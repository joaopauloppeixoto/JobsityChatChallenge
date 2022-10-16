import { Dispatch, SetStateAction, useEffect, useState } from "react";
import Package from "../../../package.json";

export const addCache = (key: string, value: any, isSessionValue: boolean) => {
  if (isSessionValue) sessionStorage.setItem(key, JSON.stringify(value));
  else localStorage.setItem(key, JSON.stringify(value));
};

export const deleteCache = (key: string, isSessionValue: boolean) => {
  if (isSessionValue) sessionStorage.removeItem(key);
  else localStorage.removeItem(key);
};

export const getCache = (key: string, isSessionValue: boolean) => {
  let cacheObj: string | null;
  if (isSessionValue) {
    cacheObj = sessionStorage.getItem(key);
  } else {
    cacheObj = localStorage.getItem(key);
  }

  if (cacheObj) return JSON.parse(cacheObj);
  else return null;
};

export default <T,>(
  cacheName: string,
  isSessionValue?: boolean
): [T | undefined, Dispatch<SetStateAction<T | undefined>>, () => void] => {
  const cacheNameWithPrefix = `useStateCached@${Package.name}.${process.env.NODE_ENV}/${cacheName}`;
  const [state, setState] = useState<T | undefined>(
    getCache(cacheNameWithPrefix, !!isSessionValue)
  );

  useEffect(() => {
    if (state !== null && state !== undefined) {
      addCache(cacheNameWithPrefix, state, !!isSessionValue);
    }
  }, [state]);

  return [
    state,
    setState,
    () => {
      deleteCache(cacheNameWithPrefix, !!isSessionValue);
      setState(undefined);
    },
  ];
};
