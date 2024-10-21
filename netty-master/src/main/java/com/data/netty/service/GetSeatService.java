package com.data.netty.service;

import com.data.netty.Bean.ClientToSpring.SeatList;
import com.data.netty.Bean.ResponseBean;
import com.data.netty.Bean.SeatData;
import com.data.netty.Bean.TcpToSpring.GetSeat.SeatDate;
import org.springframework.stereotype.Service;

@Service
public interface GetSeatService {

    public ResponseBean<String> GetSeat(SeatList seatList);

    public ResponseBean<SeatDate[]> GetSeat_(String userTime);
}
