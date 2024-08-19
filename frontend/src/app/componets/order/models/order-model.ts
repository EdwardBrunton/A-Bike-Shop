import dayjs from 'dayjs';

export interface OrderModel {
	id?: string;
	customerName: string;
	phoneNumber: string;
	email: string;
	bikeBrand: string;
	serviceType: string;
	dueDate: dayjs.Dayjs;
	notes?: string;
	isCompleted?: boolean;
}
