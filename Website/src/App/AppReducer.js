import { UPDATE_USER_INFORMATION } from './Actions';



const AppReducer = (state, action) => {
    switch (action.type) {
        case UPDATE_USER_INFORMATION:
            return { ...state, ...action.payload };
        default:
            return state;
    }

}

export default AppReducer;