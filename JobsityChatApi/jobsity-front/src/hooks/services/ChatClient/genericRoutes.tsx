import { AxiosInstance, AxiosResponse } from "axios";

const checkAxiosInstance = (instance?: AxiosInstance) => {
  if (!instance) throw Error("Axios instance is null.");
};

class GenericMethod {
  protected route = "";
  protected instance?: AxiosInstance;

  constructor(route: string, instance: AxiosInstance) {
    this.route = route;
    this.instance = instance;
  }
}

export class Get<Params, ViewModel> extends GenericMethod {
  constructor(route: string, instance: AxiosInstance) {
    super(route, instance);
  }

  get = (params: Params): Promise<AxiosResponse<ViewModel>> => {
    checkAxiosInstance(this.instance);
    return this.instance!.get<ViewModel>(this.route, { params });
  };
}

export class Put<Body, ViewModel> extends GenericMethod {
  constructor(route: string, instance: AxiosInstance) {
    super(route, instance);
  }

  put = (body: Body): Promise<AxiosResponse<ViewModel>> => {
    checkAxiosInstance(this.instance);
    return this.instance!.put<ViewModel>(this.route, body);
  };
}

export class Post<Body, ViewModel> extends GenericMethod {
  constructor(route: string, instance: AxiosInstance) {
    super(route, instance);
  }

  post = (body: Body): Promise<AxiosResponse<ViewModel>> => {
    checkAxiosInstance(this.instance);
    return this.instance!.post<ViewModel>(this.route, body);
  };
}

export class Delete<Body, ViewModel> extends GenericMethod {
  constructor(route: string, instance: AxiosInstance) {
    super(route, instance);
  }

  delete = (body: Body): Promise<AxiosResponse> => {
    checkAxiosInstance(this.instance);
    return this.instance!.delete<ViewModel>(this.route, {
      params: body,
    });
  };
}
